using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task5.Models;
using System.Threading.Tasks;
using task5.Data;

namespace task5.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }
    }
}