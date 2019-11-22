using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupStack.Data;
using GroupStack.Models;

namespace GroupStack.Controllers
{
    public class PreferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Preferences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Preferences
                .Include(p => p.Cohort)
                .Include(p => p.Student)
                .Include(p => p.ProjectFirst)
                .Include(p => p.ProjectSecond)
                .Include(p => p.ProjectThird);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Preferences/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferences = await _context.Preferences
                .Include(p => p.Cohort)
                .Include(p => p.Student)
                .Include(p => p.ProjectFirst)
                .Include(p => p.ProjectSecond)
                .Include(p => p.ProjectThird)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (preferences == null)
            {
                return NotFound();
            }

            return View(preferences);
        }

        // GET: Preferences/Create
        public IActionResult Create()
        {
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName");
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Preferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CohortId,ProjectIdFirst,ProjectIdSecond,ProjectIdThird")] Preferences preferences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preferences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName", preferences.CohortId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", preferences.StudentId);
            ViewData["ProjectIdFirst"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdFirst);
            ViewData["ProjectIdSecond"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdSecond);
            ViewData["ProjectIdThird"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdThird);
            return View(preferences);
        }

        // GET: Preferences/Edit/5
        public async Task<IActionResult> Edit(string id, int cohort)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferences = await _context.Preferences.FindAsync(id, cohort);
            if (preferences == null)
            {
                return NotFound();
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName", preferences.CohortId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Email", preferences.StudentId);
            ViewData["ProjectIdFirst"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdFirst);
            ViewData["ProjectIdSecond"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdSecond);
            ViewData["ProjectIdThird"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdThird);
            return View(preferences);
        }

        // POST: Preferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, int cohort, [Bind("StudentId,CohortId,ProjectIdFirst,ProjectIdSecond,ProjectIdThird")] Preferences preferences)
        {
            if (id != preferences.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preferences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreferencesExists(preferences.StudentId, preferences.CohortId))
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
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortId", preferences.CohortId);
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", preferences.StudentId);
            ViewData["ProjectIdFirst"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdFirst);
            ViewData["ProjectIdSecond"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdSecond);
            ViewData["ProjectIdThird"] = new SelectList(_context.Project, "ProjectId", "ProjectName", preferences.ProjectIdThird);
            return View(preferences);
        }

        // GET: Preferences/Delete/5
        public async Task<IActionResult> Delete(string id, int cohort)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferences = await _context.Preferences
                .Include(p => p.Cohort)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id && m.CohortId == cohort);
            if (preferences == null)
            {
                return NotFound();
            }

            return View(preferences);
        }

        // POST: Preferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string StudentId, int CohortId)
        {
            var preferences = await _context.Preferences.FindAsync(StudentId, CohortId);
            _context.Preferences.Remove(preferences);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreferencesExists(string id, int cohort)
        {
            return _context.Preferences.Any(e => e.StudentId == id && e.CohortId == cohort);
        }
    }
}
