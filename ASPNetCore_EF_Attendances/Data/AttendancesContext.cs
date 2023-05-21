using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Attendances.Models;

namespace ASPNetCore_EF_Attendances.Data
{
    public class ASPNetCore_EF_AttendancesContext : DbContext
    {
        public ASPNetCore_EF_AttendancesContext (DbContextOptions<ASPNetCore_EF_AttendancesContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Lesson> Lessons { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;


    }
}
