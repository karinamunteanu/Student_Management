using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management.Data;
using Student_Management.Models;

namespace Student_Management.Pages.Universities
{
    public class DetailsModel : PageModel
    {
        private readonly Student_Management.Data.Student_ManagementContext _context;

        public DetailsModel(Student_Management.Data.Student_ManagementContext context)
        {
            _context = context;
        }

        public University University { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.University.FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }
            else
            {
                University = university;
            }
            return Page();
        }
    }
}
