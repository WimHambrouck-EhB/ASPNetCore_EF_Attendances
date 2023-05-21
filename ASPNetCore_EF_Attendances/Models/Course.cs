namespace ASPNetCore_EF_Attendances.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Student>? Students { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
