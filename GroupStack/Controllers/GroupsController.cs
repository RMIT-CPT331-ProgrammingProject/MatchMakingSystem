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
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                if (User.IsInRole(Constants.AdministratorRole))
                {
                    var groups = await _context.Group.Include(g => g.Project).ToListAsync();
                    return View(groups);
                }
                else
                {
                    var groups = await _context.Group
                        .Where(g => g.Project.MentorId == User.Identity.Name
                        || g.GroupAssignments.Any(a => a.StudentId == User.Identity.Name))
                        .Include(g => g.Project).ToListAsync();
                    return View(groups);
                }
            }
            else
            {
                var groups = await _context.Group.Where(g => g.CohortId == id).Include(g => g.Project).ToListAsync();
                return View(groups);
            }
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.Group
                .Include(g => g.Project)
                .Include("GroupAssignments.Student")
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,ProjectId,GroupName")] Group group)
        {
            if (ModelState.IsValid)
            {
                /* Assigns value of Project's CohortId to Group's CohortId for easier reference in code. */
                group.CohortId = (await _context.Project.FirstOrDefaultAsync(p => p.ProjectId == group.ProjectId)).CohortId;

                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName", group.ProjectId);
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.Group.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName", group.ProjectId);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,ProjectId,GroupName")] Group group)
        {
            if (id != group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                /* Assigns value of Project's CohortId to Group's CohortId for easier reference in code. */
                group.CohortId = (await _context.Project.FirstOrDefaultAsync(p => p.ProjectId == group.ProjectId)).CohortId;

                try
                {
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.GroupId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName", group.ProjectId);
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.Group
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _context.Group.FindAsync(id);
            _context.Group.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.GroupId == id);
        }
    }
}
