using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management.Data;
using Student_Management.Models;

namespace Student_Management.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Student_Management.Data.Student_ManagementContext _context;

        public IndexModel(Student_Management.Data.Student_ManagementContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;
        public IList<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();

        [BindProperty(SupportsGet = true)]
        public int SelectedDepartmentId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Student> studentsQuery = _context.Student
                .Include(s => s.Course)
                .Include(s => s.Department)
                .Include(s => s.Faculty)
                .Include(s => s.University);

            if (!string.IsNullOrEmpty(SearchString))
            {
                // Trim the search string
                string searchStringTrimmed = SearchString.Trim();

                // Perform search for full name (combination of first name and last name)
                studentsQuery = studentsQuery.Where(s =>
                    (s.FirstName + " " + s.LastName).Contains(searchStringTrimmed));
            }

            if (SelectedDepartmentId != 0)
            {
                studentsQuery = studentsQuery.Where(s => s.DepartmentId == SelectedDepartmentId);
            }

            Student = await studentsQuery.ToListAsync();

            // Populate department filter options
            DepartmentOptions = await _context.Department
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToListAsync();
        }

    }
}