using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupStack.Data;
using GroupStack.Models;
using Microsoft.AspNetCore.Authorization;

namespace GroupStack.Controllers
{
    [Authorize]
    public class CohortsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CohortsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cohorts
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Constants.AdministratorRole))
            {
                return View(await _context.Cohort.ToListAsync());
            }
            else
            {
                var cohortsList = await _context.Cohort.Where(m => m.CoordinatorId == User.Identity.Name ||
                        m.Whitelist.Any(user => user.UserId == User.Identity.Name)).ToListAsync();
                return View(cohortsList);
            }
        }

        // GET: Cohorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohort.Include(m => m.Groups)
                .FirstOrDefaultAsync(m => m.CohortId == id);
            if (cohort == null)
            {
                return NotFound();
            }

            return View(cohort);
        }

        // GET: Cohorts/Create
        [Authorize(Roles = Constants.CoordinatorRole)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cohorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.CoordinatorRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CohortId,CoordinatorId,CohortName,UniName,MinSize,MaxSize,PreferencesDeadline,HardDeadline")] Cohort cohort)
        {
            if (ModelState.IsValid && cohort.MinSize <= cohort.MaxSize)
            {
                _context.Add(cohort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cohort);
        }

        // GET: Cohorts/Edit/5
        [Authorize(Roles = Constants.CoordinatorRole)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohort.FindAsync(id);
            if (cohort == null)
            {
                return NotFound();
            }
            return View(cohort);
        }

        // POST: Cohorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Constants.CoordinatorRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CohortId,CoordinatorId,CohortName,UniName,MinSize,MaxSize,PreferencesDeadline,HardDeadline")] Cohort cohort)
        {
            if (id != cohort.CohortId)
            {
                return NotFound();
            }

            if (ModelState.IsValid && cohort.MinSize <= cohort.MaxSize)
            {
                try
                {
                    _context.Update(cohort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CohortExists(cohort.CohortId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cohort);
        }

        // GET: Cohorts/Delete/5
        [Authorize(Roles = "Administrator,Coordinator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohort
                .FirstOrDefaultAsync(m => m.CohortId == id);
            if (cohort == null)
            {
                return NotFound();
            }

            return View(cohort);
        }

        // POST: Cohorts/Delete/5
        [Authorize(Roles = "Administrator,Coordinator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cohort = await _context.Cohort.FindAsync(id);
            _context.Cohort.Remove(cohort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Cohorts/Assign/5
        [Authorize(Roles = "Coordinator")]
        [HttpGet, ActionName("Assign")]
        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohort.Include(w => w.Whitelist).FirstOrDefaultAsync(c => c.CohortId == id);
            if (cohort == null)
            {
                return NotFound();
            }

            return View(cohort);
        }

        // POST: Cohorts/Assign/5
        [Authorize(Roles = "Coordinator")]
        [HttpPost, ActionName("Assign")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignConfirmed(int id)
        {
            var cohort = await _context.Cohort.FindAsync(id);
            var projects = await _context.Project.Where(p => p.CohortId == id).ToListAsync();
            var preferences = await _context.Preferences.Include(p => p.Student).Where(p => p.CohortId == id).ToListAsync();

            /* Create tally to count the number of students per project.*/
            var projectTally = new Dictionary<Project, int>();
            foreach (var project in projects)
            {
                projectTally.Add(project, 0);
            }

            /* */
            foreach (var preference in preferences)
            {
                projectTally[preference.ProjectFirst]++;
            }

            foreach (var project in projects)
            {
                var studentsInProject = preferences.Where(p => p.ProjectFirst == project).ToList();
                var projectGroupQty = (double)projectTally[project] / cohort.MaxSize; /* Minimum number of groups required.*/
                var groups = new List<Group>();

                for (int i = 0; i < projectGroupQty; i++)
                {
                    groups.Add(new Group(project, id));
                }

                foreach (var group in groups)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(group);
                        await _context.SaveChangesAsync();
                    }

                    while (0 < studentsInProject.Count && group.GroupAssignments.Count < cohort.MaxSize)
                    {
                        var nextStudentPreferences = studentsInProject.FirstOrDefault();
                        var groupAssignment = new GroupAssignment(group, nextStudentPreferences.Student);

                        if (ModelState.IsValid)
                        {
                            _context.Add(groupAssignment);
                            await _context.SaveChangesAsync();
                        }
                        studentsInProject.Remove(nextStudentPreferences);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CohortExists(int id)
        {
            return _context.Cohort.Any(e => e.CohortId == id);
        }
    }
}
