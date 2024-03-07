using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Attendances.Data;
using ASPNetCore_EF_Attendances.Models;
using Microsoft.Data.SqlClient;

namespace ASPNetCore_EF_Attendances.Controllers
{
    public class CourseStudentsController : Controller
    {
        private readonly AttendancesContext _context;
        private readonly ILogger<CourseStudentsController> _logger;
        

        public CourseStudentsController(AttendancesContext context, ILogger<CourseStudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: CourseStudents
        public async Task<IActionResult> Index()
        {
            var attendancesContext = _context.CourseStudents.Include(c => c.Course).Include(c => c.Student);
            return View(await attendancesContext.ToListAsync());
        }

        // GET: CourseStudents/Create
        public IActionResult Create()
        {
            //ViewData["CourseID"] = new SelectList(_context.Courses, nameof(Course.ID), nameof(Course.Name));

            ViewData["CourseID"] = new SelectList(_context.Courses.OrderBy(c => c.Name), nameof(Course.ID), nameof(Course.Name));
            ViewData["StudentID"] = new SelectList(_context.Students.OrderBy(s => s.LastName), nameof(Student.ID), nameof(Student.FullName));
            return View();
        }

        // POST: CourseStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,StudentID")] CourseStudent courseStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseStudent);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // 2627 = duplicate primary key, maw deze student is al gekoppeld aan dit vak
                    // -- https://learn.microsoft.com/en-us/sql/relational-databases/errors-events/database-engine-events-and-errors-2000-to-2999
                    if(ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                    {
                        ModelState.AddModelError("", "This student is already enrolled in this course.");
                    } else
                    {
                        _logger.LogError(1000, ex, "An error occured while saving a CourseStudent.");
                        ModelState.AddModelError("", "A database error occured, contact your system administrator. LogEventId: 1000. Message: " + ex.Message);
                    }
                }
            }
            ViewData["CourseID"] = new SelectList(_context.Courses.OrderBy(c => c.Name), nameof(Course.ID), nameof(Course.Name));
            ViewData["StudentID"] = new SelectList(_context.Students.OrderBy(s => s.LastName), nameof(Student.ID), nameof(Student.FullName));
            return View(courseStudent);
        }
    }
}
