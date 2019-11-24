using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupStack.Data;
using GroupStack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GroupStack.Controllers
{
    [Authorize(Roles = "Administrator,Coordinator")]
    public class WhitelistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public WhitelistsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Whitelists
        public async Task<IActionResult> Index()
        {
            var whitelist = await _context.Whitelist.Include(w => w.Cohort)
                    .OrderBy(w => w.UserId)
                    .OrderByDescending(w => w.IsMentor)
                    .OrderBy(w => w.CohortId)
                    .ToListAsync();
            return View(whitelist);
        }

        // GET: Whitelists
        [Route("Whitelists/Index/{cohortNo}")]
        public async Task<IActionResult> Index(int cohortNo)
        {
            var whitelist = await _context.Whitelist.Include(w => w.Cohort).Where(x=>x.CohortId == cohortNo).ToListAsync();
            ViewData["cohortName"] = (await _context.Cohort.FirstAsync(c => c.CohortId == cohortNo)).CohortName;
            return View(whitelist);
        }

        // GET: Whitelists/Details/5
        public async Task<IActionResult> Details(int? cohort, string user)
        {
            if (cohort == null)
            {
                return NotFound();
            }

            var whitelist = await _context.Whitelist
                .Include(w => w.Cohort)
                .FirstOrDefaultAsync(m => m.CohortId == cohort && m.UserId == user);
            if (whitelist == null)
            {
                return NotFound();
            }

            return View(whitelist);
        }

        // GET: Whitelists/Create
        // Administrator can add users to any cohort; Coordinators can add users to their own cohorts.
        public IActionResult Create()
        {
            if (User.IsInRole(Constants.AdministratorRole))
            {
                ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName");
            }
            else
            {
                ViewData["CohortId"] = new SelectList(_context.Cohort.Where(c => c.CoordinatorId == User.Identity.Name), "CohortId", "CohortName");
            }
            return View();
        }

        // GET: Whitelists/Create
        [Route("Whitelists/Create/{cohortNo}")]
        public IActionResult Create(int cohortNo)
        {
            ViewData["CohortId"] = new SelectList(_context.Cohort.Where(x=>x.CohortId == cohortNo), "CohortId", "CohortName");
            return View();
        }

        // POST: Whitelists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CohortId,UserId,IsMentor")] Whitelist whitelist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whitelist);
                await _context.SaveChangesAsync();

                /* Update user privileges.*/
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == whitelist.UserId.ToLower());
                if (user != null)
                {
                    if (whitelist.IsMentor)
                    {
                        await _userManager.AddToRoleAsync(user, Constants.MentorRole);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Constants.StudentRole);
                    }
                }

                return RedirectToAction(nameof(Index), new { id = whitelist.CohortId });
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName", whitelist.CohortId);
            return View(whitelist);
        }

        // GET: Whitelists/Edit/5
        public async Task<IActionResult> Edit(int? cohort, string user)
        {
            if (cohort == null)
            {
                return NotFound();
            }

            var whitelist = await _context.Whitelist.FindAsync(cohort, user);
            if (whitelist == null)
            {
                return NotFound();
            }

            if (User.IsInRole(Constants.AdministratorRole))
            {
                ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName", whitelist.CohortId);
            }
            else
            {
                ViewData["CohortId"] = new SelectList(_context.Cohort.Where(c => c.CoordinatorId == User.Identity.Name), "CohortId", "CohortName", whitelist.CohortId);
            }

            return View(whitelist);
        }

        // POST: Whitelists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int CohortId, string UserId, [Bind("CohortId,UserId,IsMentor")] Whitelist whitelist)
        {
            if (CohortId != whitelist.CohortId || UserId != whitelist.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whitelist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhitelistExists(whitelist.CohortId, whitelist.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = whitelist.CohortId });
            }
            ViewData["CohortId"] = new SelectList(_context.Cohort, "CohortId", "CohortName", whitelist.CohortId);
            return View(whitelist);
        }

        // GET: Whitelists/Delete/5
        public async Task<IActionResult> Delete(int? cohort, string user)
        {
            if (cohort == null)
            {
                return NotFound();
            }

            var whitelist = await _context.Whitelist
                .Include(w => w.Cohort)
                .FirstOrDefaultAsync(m => m.CohortId == cohort && m.UserId == user);
            if (whitelist == null)
            {
                return NotFound();
            }

            return View(whitelist);
        }

        // POST: Whitelists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int CohortId, string UserId)
        {
            var whitelist = await _context.Whitelist.FindAsync(CohortId, UserId);
            _context.Whitelist.Remove(whitelist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhitelistExists(int cohort, string user)
        {
            return _context.Whitelist.Any(e => e.CohortId == cohort && e.UserId == user);
        }
    }
}
