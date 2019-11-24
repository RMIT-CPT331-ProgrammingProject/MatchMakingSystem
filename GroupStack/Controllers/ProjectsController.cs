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
using Microsoft.AspNetCore.Identity;

namespace GroupStack.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProjectsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Projects
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var projects = await _context.Project.Include(p => p.Cohort).Include(p => p.Mentor).OrderBy(p => p.ProjectName).OrderBy(p => p.Cohort.CohortName).ToListAsync();
                return View(projects);
            }
            else
            {
                var projects = await _context.Project.Include(p => p.Cohort).Include(p => p.Mentor).OrderBy(p => p.ProjectName).Where(p => p.CohortId == id).ToListAsync();
                ViewData["id"] = id;
                ViewData["cohortName"] = (await _context.Cohort.FindAsync(id)).CohortName;
                return View(projects);
            }
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Cohort)
                .Include(p => p.Mentor)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles = "Coordinator,Mentor")]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName");
            }
            else
            {
                ViewData["CohortId"] = new SelectList(_context.Cohort.Where(c => c.CohortId == id), "CohortId", "CohortName");
                ViewData["MinSize"] = _context.Cohort.Find(id).MinSize;
                ViewData["MaxSize"] = _context.Cohort.Find(id).MaxSize;
            }
            ViewData["MentorId"] = new SelectList((await _userManager.GetUsersInRoleAsync(Constants.MentorRole)).ToList(), "Id", "Email");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Coordinator,Mentor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,CohortId,MentorId,MinSize,MaxSize,MaxGroups,ProjectName,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = project.CohortId });
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortId", project.CohortId);
            ViewData["MentorId"] = new SelectList((await _userManager.GetUsersInRoleAsync(Constants.MentorRole)).ToList(), "Id", "Email");
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Coordinator,Mentor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName", project.CohortId);
            ViewData["MentorId"] = new SelectList(_context.Users, "Id", "Email", project.MentorId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Coordinator,Mentor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,CohortId,MentorId,MinSize,MaxSize,MaxGroups,ProjectName,Description")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = project.CohortId });
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortId", project.CohortId);
            ViewData["MentorId"] = new SelectList((await _userManager.GetUsersInRoleAsync(Constants.MentorRole)).ToList(), "Id", "Email", project.MentorId);
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Coordinator,Mentor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Cohort)
                .Include(p => p.Mentor)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}
