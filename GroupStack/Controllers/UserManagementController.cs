using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupStack.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GroupStack.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserManagementController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = Constants.AdministratorRole)]
        public IActionResult Index()
        {
            return View();
        }

        // POST: UserManagement/Update
        [Authorize(Roles = Constants.AdministratorRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string UserId, string Administrator = null, string Coordinator = null,
                string Mentor = null, string Student = null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            if (user != null)
            {
                if (Administrator != null)
                {
                    await _userManager.AddToRoleAsync(user, Constants.AdministratorRole);
                }

                if (Coordinator != null)
                {
                    await _userManager.AddToRoleAsync(user, Constants.CoordinatorRole);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, Constants.CoordinatorRole);
                }

                if (Mentor != null)
                {
                    await _userManager.AddToRoleAsync(user, Constants.MentorRole);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, Constants.MentorRole);
                }

                if (Student != null)
                {
                    await _userManager.AddToRoleAsync(user, Constants.StudentRole);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, Constants.StudentRole);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        /* Allows the first user to set themselves as the Administrator.*/
        public async Task<IActionResult> Initialise()
        {
            if ((await _context.Users.CountAsync()) == 1)
            {
                var user = await _context.Users.FirstAsync();
                await _userManager.AddToRoleAsync(user, Constants.AdministratorRole);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}