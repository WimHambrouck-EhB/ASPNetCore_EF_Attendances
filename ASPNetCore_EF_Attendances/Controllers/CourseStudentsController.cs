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
        

        public CourseStudentsController(AttendancesContext context)
        {
            _context = context;
        }

        // GET: CourseStudents
        public async Task<IActionResult> Index()
        {
            var attendancesContext = _context.CourseStudents.Include(c => c.Course).Include(c => c.Student);
            return View(await attendancesContext.ToListAsync());
        }

        // GET: CourseStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseStudents == null)
            {
                return NotFound();
            }

            var courseStudent = await _context.CourseStudents
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            return View(courseStudent);
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

            /*
             * catch (DbUpdateException ex)
    {
        // Handle the exception here. For example, you can log the error message:
        Console.WriteLine(ex.Message);

        // You can also add a model error to display in the view
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
    }
             */
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
                        
                        ModelState.AddModelError("", "A database error occured, contact you system administrator.");
                    }
                }
            }
            ViewData["CourseID"] = new SelectList(_context.Courses.OrderBy(c => c.Name), nameof(Course.ID), nameof(Course.Name));
            ViewData["StudentID"] = new SelectList(_context.Students.OrderBy(s => s.LastName), nameof(Student.ID), nameof(Student.FullName));
            return View(courseStudent);
        }

        // GET: CourseStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseStudents == null)
            {
                return NotFound();
            }

            var courseStudent = await _context.CourseStudents.FindAsync(id);
            if (courseStudent == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "ID", courseStudent.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", courseStudent.StudentID);
            return View(courseStudent);
        }

        // POST: CourseStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,StudentID")] CourseStudent courseStudent)
        {
            if (id != courseStudent.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseStudentExists(courseStudent.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "ID", courseStudent.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", courseStudent.StudentID);
            return View(courseStudent);
        }

        // GET: CourseStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseStudents == null)
            {
                return NotFound();
            }

            var courseStudent = await _context.CourseStudents
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            return View(courseStudent);
        }

        // POST: CourseStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseStudents == null)
            {
                return Problem("Entity set 'AttendancesContext.CourseStudents'  is null.");
            }
            var courseStudent = await _context.CourseStudents.FindAsync(id);
            if (courseStudent != null)
            {
                _context.CourseStudents.Remove(courseStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseStudentExists(int id)
        {
            return (_context.CourseStudents?.Any(e => e.CourseID == id)).GetValueOrDefault();
        }
    }
}
