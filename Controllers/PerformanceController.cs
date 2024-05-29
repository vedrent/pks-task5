using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task5.Models;
using System.Linq;
using System.Threading.Tasks;
using task5.Data;

namespace task5.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerformanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var performances = from p in _context.Performances
                select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                performances = performances.Where(s => s.Subject.Contains(searchString));
            }

            return View(await performances.ToListAsync());
        }
    }
}