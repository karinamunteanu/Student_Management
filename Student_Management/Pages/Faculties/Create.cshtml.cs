using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Management.Data;
using Student_Management.Models;

namespace Student_Management.Pages.Faculties
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
        ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Faculty Faculty { get; set; } = default!;

  
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Faculty.Add(Faculty);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
