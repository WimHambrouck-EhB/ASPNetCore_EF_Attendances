using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Attendances.Models;

namespace ASPNetCore_EF_Attendances.Data
{
    public class AttendancesContext : DbContext
    {
        public AttendancesContext(DbContextOptions<AttendancesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseID, cs.StudentID });

            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, FirstName = "Laura", LastName = "Palmer" },
                new Student { ID = 2, FirstName = "Donna", LastName = "Hayward" },
                new Student { ID = 3, FirstName = "Audrey", LastName = "Horne" },
                new Student { ID = 4, FirstName = "James", LastName = "Hurley" },
                new Student { ID = 5, FirstName = "Maddy", LastName = "Ferguson" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Name = "Data Essentials" },
                new Course { ID = 2, Name = "Data Advanced" },
                new Course { ID = 3, Name = ".NET Essentials" },
                new Course { ID = 4, Name = ".NET Advanced" },
                new Course { ID = 5, Name = "Android Development" },
                new Course { ID = 6, Name = "Integration Project" },
                new Course { ID = 7, Name = "Expert Lab" },
                new Course { ID = 8, Name = "Programming Project 1" }
            );

            modelBuilder.Entity<CourseStudent>().HasData(
                new CourseStudent { CourseID = 1, StudentID = 1 },
                new CourseStudent { CourseID = 1, StudentID = 2 },
                new CourseStudent { CourseID = 1, StudentID = 3 },
                new CourseStudent { CourseID = 1, StudentID = 4 },
                new CourseStudent { CourseID = 1, StudentID = 5 },
                new CourseStudent { CourseID = 2, StudentID = 1 },
                new CourseStudent { CourseID = 2, StudentID = 2 },
                new CourseStudent { CourseID = 2, StudentID = 3 },
                new CourseStudent { CourseID = 2, StudentID = 4 },
                new CourseStudent { CourseID = 2, StudentID = 5 },
                new CourseStudent { CourseID = 3, StudentID = 1 },
                new CourseStudent { CourseID = 3, StudentID = 2 },
                new CourseStudent { CourseID = 3, StudentID = 3 },
                new CourseStudent { CourseID = 3, StudentID = 4 },
                new CourseStudent { CourseID = 3, StudentID = 5 },
                new CourseStudent { CourseID = 4, StudentID = 1 },
                new CourseStudent { CourseID = 4, StudentID = 2 },
                new CourseStudent { CourseID = 4, StudentID = 3 },
                new CourseStudent { CourseID = 4, StudentID = 4 },
                new CourseStudent { CourseID = 4, StudentID = 5 },
                new CourseStudent { CourseID = 5, StudentID = 1 },
                new CourseStudent { CourseID = 5, StudentID = 2 },
                new CourseStudent { CourseID = 5, StudentID = 3 },
                new CourseStudent { CourseID = 5, StudentID = 4 },
                new CourseStudent { CourseID = 5, StudentID = 5 },
                new CourseStudent { CourseID = 6, StudentID = 1 },
                new CourseStudent { CourseID = 6, StudentID = 2 },
                new CourseStudent { CourseID = 6, StudentID = 3 },
                new CourseStudent { CourseID = 6, StudentID = 4 },
                new CourseStudent { CourseID = 6, StudentID = 5 },
                new CourseStudent { CourseID = 7, StudentID = 1 },
                new CourseStudent { CourseID = 7, StudentID = 2 },
                new CourseStudent { CourseID = 7, StudentID = 3 },
                new CourseStudent { CourseID = 7, StudentID = 4 },
                new CourseStudent { CourseID = 7, StudentID = 5 },
                new CourseStudent { CourseID = 8, StudentID = 1 },
                new CourseStudent { CourseID = 8, StudentID = 2 },
                new CourseStudent { CourseID = 8, StudentID = 3 },
                new CourseStudent { CourseID = 8, StudentID = 4 },
                new CourseStudent { CourseID = 8, StudentID = 5 }
           );
        }

        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Lesson> Lessons { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<CourseStudent> CourseStudents { get; set; } = default!;



    }
}
