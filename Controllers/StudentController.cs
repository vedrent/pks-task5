﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task5.Models;
using task5.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace task5.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = await _context.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}