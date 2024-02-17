namespace Student_Management.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key for the university this faculty belongs to
        public int UniversityId { get; set; }

        // Navigation property for the university this faculty belongs to
        public University? University { get; set; }
    }
}
