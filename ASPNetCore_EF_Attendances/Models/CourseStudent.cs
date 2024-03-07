using System.ComponentModel.DataAnnotations;

namespace ASPNetCore_EF_Attendances.Models
{
    public class CourseStudent
    {
        // primary key gedefinieerd met FluentAPI in DbContext (methode OnModelCreating)
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        [Display(Name = "Student")] 
        public int StudentID { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
