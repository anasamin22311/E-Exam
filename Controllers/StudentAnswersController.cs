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
    public class StudentAnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentAnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentAnswers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentAnswers.Include(s => s.Answer).Include(s => s.ExamQuestion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentAnswers == null)
            {
                return NotFound();
            }

            var studentAnswer = await _context.StudentAnswers
                .Include(s => s.Answer)
                .Include(s => s.ExamQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentAnswer == null)
            {
                return NotFound();
            }

            return View(studentAnswer);
        }

        // GET: StudentAnswers/Create
        public IActionResult Create()
        {
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Text");
            ViewData["ExamQuestionId"] = new SelectList(_context.ExamQuestions, "Id", "Id");
            return View();
        }

        // POST: StudentAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExamQuestionId,AnswerId")] StudentAnswer studentAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Text", studentAnswer.AnswerId);
            ViewData["ExamQuestionId"] = new SelectList(_context.ExamQuestions, "Id", "Id", studentAnswer.ExamQuestionId);
            return View(studentAnswer);
        }

        // GET: StudentAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentAnswers == null)
            {
                return NotFound();
            }

            var studentAnswer = await _context.StudentAnswers.FindAsync(id);
            if (studentAnswer == null)
            {
                return NotFound();
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Text", studentAnswer.AnswerId);
            ViewData["ExamQuestionId"] = new SelectList(_context.ExamQuestions, "Id", "Id", studentAnswer.ExamQuestionId);
            return View(studentAnswer);
        }

        // POST: StudentAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExamQuestionId,AnswerId")] StudentAnswer studentAnswer)
        {
            if (id != studentAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAnswerExists(studentAnswer.Id))
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
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Text", studentAnswer.AnswerId);
            ViewData["ExamQuestionId"] = new SelectList(_context.ExamQuestions, "Id", "Id", studentAnswer.ExamQuestionId);
            return View(studentAnswer);
        }

        // GET: StudentAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentAnswers == null)
            {
                return NotFound();
            }

            var studentAnswer = await _context.StudentAnswers
                .Include(s => s.Answer)
                .Include(s => s.ExamQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentAnswer == null)
            {
                return NotFound();
            }

            return View(studentAnswer);
        }

        // POST: StudentAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentAnswers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentAnswers'  is null.");
            }
            var studentAnswer = await _context.StudentAnswers.FindAsync(id);
            if (studentAnswer != null)
            {
                _context.StudentAnswers.Remove(studentAnswer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAnswerExists(int id)
        {
          return (_context.StudentAnswers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
