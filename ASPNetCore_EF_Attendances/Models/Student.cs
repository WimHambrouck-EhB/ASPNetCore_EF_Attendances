namespace ASPNetCore_EF_Attendances.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Naam { get; set; } = string.Empty;
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
