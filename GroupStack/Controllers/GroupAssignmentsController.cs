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
    public class GroupAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroupAssignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GroupAssignment.Include(g => g.Group).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GroupAssignments/Details/5
        public async Task<IActionResult> Details(int? group, string student)
        {
            if (group == null)
            {
                return NotFound();
            }

            var groupAssignment = await _context.GroupAssignment
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupId == group && m.StudentId == student);
            if (groupAssignment == null)
            {
                return NotFound();
            }

            return View(groupAssignment);
        }

        // GET: GroupAssignments/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupName");
            return View();
        }

        // POST: GroupAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,StudentId,Role")] GroupAssignment groupAssignment)
        {
            /* Convert user-readable email to internal ID. */
            var student = await _context.Users.FirstOrDefaultAsync(u => u.Email == groupAssignment.StudentId);
            if (student == null)
            {
                return NotFound();
            }
            groupAssignment.StudentId = student.Id;
            groupAssignment.Student = student;

            if (ModelState.IsValid)
            {
                _context.Add(groupAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupName", groupAssignment.GroupId);
            return View(groupAssignment);
        }

        // GET: GroupAssignments/Edit/5
        public async Task<IActionResult> Edit(int? group, string student)
        {
            if (group == null)
            {
                return NotFound();
            }

            var groupAssignment = await _context.GroupAssignment.FindAsync(group, student);
            if (groupAssignment == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupId", groupAssignment.GroupId);
            return View(groupAssignment);
        }

        // POST: GroupAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int group, string student, [Bind("GroupId,StudentId,Role")] GroupAssignment groupAssignment)
        {
            if (group != groupAssignment.GroupId || student != groupAssignment.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupAssignmentExists(groupAssignment.GroupId, groupAssignment.StudentId))
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
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupId", groupAssignment.GroupId);
            return View(groupAssignment);
        }

        // GET: GroupAssignments/Delete/5
        public async Task<IActionResult> Delete(int? group, string student)
        {
            if (group == null)
            {
                return NotFound();
            }

            var groupAssignment = await _context.GroupAssignment
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupId == group && m.StudentId == student);
            if (groupAssignment == null)
            {
                return NotFound();
            }

            return View(groupAssignment);
        }

        // POST: GroupAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int GroupId, string StudentId)
        {
            var groupAssignment = await _context.GroupAssignment.FindAsync(GroupId, StudentId);
            _context.GroupAssignment.Remove(groupAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupAssignmentExists(int group, string student)
        {
            return _context.GroupAssignment.Any(e => e.GroupId == group && e.StudentId == student);
        }
    }
}
