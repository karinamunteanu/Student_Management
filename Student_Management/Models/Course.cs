namespace Student_Management.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

    

        // Navigation property for departments associated with this course
        public ICollection<Department>? Departments { get; set; }
    }
}
