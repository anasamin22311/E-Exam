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
    public class UserExamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserExams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserExams.Include(u => u.Exam).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserExams == null)
            {
                return NotFound();
            }

            var userExam = await _context.UserExams
                .Include(u => u.Exam)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userExam == null)
            {
                return NotFound();
            }

            return View(userExam);
        }

        // GET: UserExams/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserExams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ExamId")] UserExam userExam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userExam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", userExam.ExamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userExam.UserId);
            return View(userExam);
        }

        // GET: UserExams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserExams == null)
            {
                return NotFound();
            }

            var userExam = await _context.UserExams.FindAsync(id);
            if (userExam == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", userExam.ExamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userExam.UserId);
            return View(userExam);
        }

        // POST: UserExams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ExamId")] UserExam userExam)
        {
            if (id != userExam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userExam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExamExists(userExam.Id))
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
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", userExam.ExamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userExam.UserId);
            return View(userExam);
        }

        // GET: UserExams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserExams == null)
            {
                return NotFound();
            }

            var userExam = await _context.UserExams
                .Include(u => u.Exam)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userExam == null)
            {
                return NotFound();
            }

            return View(userExam);
        }

        // POST: UserExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserExams == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserExams'  is null.");
            }
            var userExam = await _context.UserExams.FindAsync(id);
            if (userExam != null)
            {
                _context.UserExams.Remove(userExam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExamExists(int id)
        {
          return (_context.UserExams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
