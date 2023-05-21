namespace ASPNetCore_EF_Attendances.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<CourseStudent>? CourseStudents { get; set; }
        public List<Course>? Courses { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
