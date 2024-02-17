using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Foreign keys
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public int UniversityId { get; set; }

        // Navigation properties
        public Department? Department { get; set; }
        public Faculty? Faculty { get; set; }
        [ForeignKey("UniversityId")]
        public University? University { get; set; }
        public Course? Course { get; set; }

        // Navigation property for courses
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
