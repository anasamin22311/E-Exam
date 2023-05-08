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
    public class ExamQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExamQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExamQuestions.Include(e => e.Exam).Include(e => e.Question);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExamQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamQuestions == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestions
                .Include(e => e.Exam)
                .Include(e => e.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // GET: ExamQuestions/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Text");
            return View();
        }

        // POST: ExamQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExamId,QuestionId")] ExamQuestion examQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", examQuestion.ExamId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Text", examQuestion.QuestionId);
            return View(examQuestion);
        }

        // GET: ExamQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamQuestions == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestions.FindAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", examQuestion.ExamId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Text", examQuestion.QuestionId);
            return View(examQuestion);
        }

        // POST: ExamQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExamId,QuestionId")] ExamQuestion examQuestion)
        {
            if (id != examQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamQuestionExists(examQuestion.Id))
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
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", examQuestion.ExamId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Text", examQuestion.QuestionId);
            return View(examQuestion);
        }

        // GET: ExamQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamQuestions == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestions
                .Include(e => e.Exam)
                .Include(e => e.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // POST: ExamQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamQuestions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExamQuestions'  is null.");
            }
            var examQuestion = await _context.ExamQuestions.FindAsync(id);
            if (examQuestion != null)
            {
                _context.ExamQuestions.Remove(examQuestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamQuestionExists(int id)
        {
          return (_context.ExamQuestions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
