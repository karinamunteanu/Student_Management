using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Management.Data;
using Student_Management.Models;

namespace Student_Management.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Student_Management.Data.Student_ManagementContext _context;

        public CreateModel(Student_Management.Data.Student_ManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "Id", "Name");
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Name");
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name"); // Populate courses in ViewBag
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}