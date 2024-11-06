namespace APIDemoB.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        // Relación de uno a muchos: un `Course` puede tener muchas `Enrollments`
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
