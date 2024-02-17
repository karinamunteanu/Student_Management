using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management.Models;

namespace Student_Management.Data
{
    public class Student_ManagementContext : DbContext
    {
        public Student_ManagementContext (DbContextOptions<Student_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Management.Models.University> University { get; set; } = default!;
        public DbSet<Student_Management.Models.Faculty> Faculty { get; set; } = default!;
        public DbSet<Student_Management.Models.Department> Department { get; set; } = default!;
        public DbSet<Student_Management.Models.Course> Course { get; set; } = default!;
        public DbSet<Student_Management.Models.Student> Student { get; set; } = default!;
        
    }
}
