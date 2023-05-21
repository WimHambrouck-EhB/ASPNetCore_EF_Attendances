namespace ASPNetCore_EF_Attendances.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; } = null!;
        public ICollection<Student>? Students { get; set; }

    }
}
