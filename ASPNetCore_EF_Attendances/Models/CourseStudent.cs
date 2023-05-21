namespace ASPNetCore_EF_Attendances.Models
{
    public class CourseStudent
    {        
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
