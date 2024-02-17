namespace Student_Management.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for faculties associated with this university
        public ICollection<Faculty>? Faculties { get; set; }
    }
}
