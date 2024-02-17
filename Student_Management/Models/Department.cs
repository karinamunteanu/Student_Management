namespace Student_Management.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for courses associated with this department
        public ICollection<Course>? Courses { get; set; }
    }
}
