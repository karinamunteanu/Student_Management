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
    public class IndexModel : PageModel
    {
        private readonly Student_Management.Data.Student_ManagementContext _context;

        public IndexModel(Student_Management.Data.Student_ManagementContext context)
        {
            _context = context;
        }

        public IList<University> University { get; set; }

        public IList<Faculty> Faculties { get; set; }

        public int UniversityID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            University = await _context.University.ToListAsync();

            if (id != null)
            {
                UniversityID = id.Value;
                Faculties = await _context.Faculty
                    .Where(f => f.UniversityId == id.Value)
                    .ToListAsync();
            }
        }
    }
}