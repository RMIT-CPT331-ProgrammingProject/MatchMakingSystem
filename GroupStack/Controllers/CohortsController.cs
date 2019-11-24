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

            var cohort = await _context.Cohort.Include("Groups.GroupAssignments.Student")
                .FirstOrDefaultAsync(m => m.CohortId == id);
            if (cohort == null)
            {
                return NotFound();
            }

            /* Check if user has already selected preferences for this cohort.*/
            if (User.IsInRole(Constants.StudentRole)
                && _context.Preferences.Any(p => p.CohortId == id && p.Student.Email == User.Identity.Name))
            {
                ViewData["PreferencesSelected"] = true;
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
        // Page to automatically assign students into groups.
        [Authorize(Roles = "Coordinator")]
        [HttpGet, ActionName("Assign")]
        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["preferenceCount"] = _context.Preferences.Where(p => p.CohortId == id).ToList().Count;
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
            var cohortProjects = await _context.Project.Where(p => p.CohortId == id).ToListAsync();
            var cohortPreferences = await _context.Preferences.Include(p => p.Student).Where(p => p.CohortId == id).ToListAsync();

            /* Create container to organise students as they are sorted.*/
            var tempAssignments = new Dictionary<Project, List<Preferences>>();
            var assignmentsValidated = new Dictionary<Project, bool>();
            foreach (var project in cohortProjects)
            {
                tempAssignments.Add(project, new List<Preferences>());
                assignmentsValidated.Add(project, false);
            }

            /* Allocate students to their first preferences.*/
            foreach (var preference in cohortPreferences)
            {
                tempAssignments[preference.ProjectFirst].Add(preference);
            }

            /* Attempt to reallocate students if first preference is not suitable.*/
            var round = 0; /* Stop optimisation after 5 rounds.*/
            while (assignmentsValidated.Any(a => a.Value == false) && round < 5)
            {
                foreach (var project in cohortProjects)
                {
                    var studentsForProject = tempAssignments[project].Count;
                    var projectGroupQty = (double)studentsForProject / project.MaxSize;
                    /* Check if either there aren't enough students to fill a group or there are too many students
                     * to fill the maximum number of groups.*/
                    if (projectGroupQty * project.MinSize <= studentsForProject
                        && studentsForProject <= project.MaxSize * project.MaxGroups)
                    {
                        assignmentsValidated[project] = true;
                    }
                    else
                    {
                        assignmentsValidated[project] = false;
                    }
                }

                foreach (var projectValidated in assignmentsValidated.Where(a=> a.Value == false))
                {
                    var project = projectValidated.Key;
                    var excessStudents = tempAssignments[project].Count - project.MaxSize * project.MaxGroups;
                    /* If a project has more than the maximum number of students reallocate from first preference to
                     * second preference.*/
                    if (0 < excessStudents)
                    {
                        var tempAssignmentsFirstChoice = tempAssignments[project].Where(a => a.ProjectFirst == project).ToList();
                        for (var i = 0; i < excessStudents; i++)
                        {
                            var studentPreferences = tempAssignmentsFirstChoice.FirstOrDefault();
                            if (studentPreferences != null)
                            {
                                tempAssignments[studentPreferences.ProjectSecond].Add(studentPreferences);
                                tempAssignments[studentPreferences.ProjectFirst].Remove(studentPreferences);
                                tempAssignmentsFirstChoice.Remove(studentPreferences);
                            }
                        }
                    }
                }
                round++;
            }

            foreach (var project in cohortProjects)
            {
                var groups = new List<Group>();
                var projectGroupQty = (double)tempAssignments[project].Count / project.MaxSize;

                /* Create new groups sufficient to hold the students for this project. */
                for (int i = 0; i < projectGroupQty; i++)
                {
                    var newGroup = new Group(project, id);
                    
                    if (ModelState.IsValid)
                    {
                        _context.Add(newGroup);
                        await _context.SaveChangesAsync();
                    }

                    while (0 < tempAssignments[project].Count && newGroup.GroupAssignments.Count < project.MaxSize)
                    {
                        var nextPreference = tempAssignments[project].FirstOrDefault();
                        var newGroupAssignment = new GroupAssignment(newGroup, nextPreference.Student);

                        if (ModelState.IsValid)
                        {
                            _context.Add(newGroupAssignment);
                            await _context.SaveChangesAsync();
                        }
                        tempAssignments[project].Remove(nextPreference);
                    }
                }
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        private bool CohortExists(int id)
        {
            return _context.Cohort.Any(e => e.CohortId == id);
        }
    }
}
