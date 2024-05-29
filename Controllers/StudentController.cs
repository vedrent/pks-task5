using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task5.Data;
using task5.Models;
using System.Threading.Tasks;
using System.Linq;

namespace task5.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Performance()
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Challenge();

            var performances = await _context.Performances
                .Where(p => p.StudentEmail == user.Email)
                .OrderBy(p => p.Semester)
                .ThenByDescending(p => p.Grade)
                .ToListAsync();

            return View(performances);
        }

        public async Task<IActionResult> Achievements()
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Challenge();

            var achievements = await _context.Achievements
                .Where(a => a.StudentEmail == user.Email)
                .OrderBy(a => a.Date)
                .ToListAsync();

            return View(achievements);
        }

        public async Task<IActionResult> Teachers()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return View(teachers);
        }
    }
}