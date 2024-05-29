using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task5.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using task5.Data;

namespace task5.Controllers
{
    public class AchievementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AchievementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? filterDate, string filterType)
        {
            var achievements = from a in _context.Achievements
                select a;

            if (filterDate.HasValue)
            {
                achievements = achievements.Where(a => a.Date == filterDate.Value);
            }

            if (!string.IsNullOrEmpty(filterType))
            {
                achievements = achievements.Where(a => a.Type == filterType);
            }

            return View(await achievements.ToListAsync());
        }
    }
}