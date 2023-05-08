using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Exam.Data;
using E_Exam.Models;

namespace E_Exam.Controllers
{
    public class StudentResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentResults
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentResult.Include(s => s.Student).Include(s => s.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentResult == null)
            {
                return NotFound();
            }

            var studentResult = await _context.StudentResult
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentResult == null)
            {
                return NotFound();
            }

            return View(studentResult);
        }

        // GET: StudentResults/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Department");
            return View();
        }

        // POST: StudentResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,SubjectId,Id,Score,ExamDate")] StudentResult studentResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", studentResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Department", studentResult.SubjectId);
            return View(studentResult);
        }

        // GET: StudentResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentResult == null)
            {
                return NotFound();
            }

            var studentResult = await _context.StudentResult.FindAsync(id);
            if (studentResult == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", studentResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Department", studentResult.SubjectId);
            return View(studentResult);
        }

        // POST: StudentResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,SubjectId,Id,Score,ExamDate")] StudentResult studentResult)
        {
            if (id != studentResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentResultExists(studentResult.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", studentResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Department", studentResult.SubjectId);
            return View(studentResult);
        }

        // GET: StudentResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentResult == null)
            {
                return NotFound();
            }

            var studentResult = await _context.StudentResult
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentResult == null)
            {
                return NotFound();
            }

            return View(studentResult);
        }

        // POST: StudentResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentResult == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentResult'  is null.");
            }
            var studentResult = await _context.StudentResult.FindAsync(id);
            if (studentResult != null)
            {
                _context.StudentResult.Remove(studentResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentResultExists(int id)
        {
          return (_context.StudentResult?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
