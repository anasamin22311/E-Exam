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
    public class TrueFalseQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrueFalseQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrueFalseQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrueFalseQuestion.Include(t => t.Chapter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TrueFalseQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrueFalseQuestion == null)
            {
                return NotFound();
            }

            var trueFalseQuestion = await _context.TrueFalseQuestion
                .Include(t => t.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trueFalseQuestion == null)
            {
                return NotFound();
            }

            return View(trueFalseQuestion);
        }

        // GET: TrueFalseQuestions/Create
        public IActionResult Create()
        {
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id");
            return View();
        }

        // POST: TrueFalseQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorrectAnswer,Id,Text,Type,Difficulty,ChapterId")] TrueFalseQuestion trueFalseQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trueFalseQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", trueFalseQuestion.ChapterId);
            return View(trueFalseQuestion);
        }

        // GET: TrueFalseQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrueFalseQuestion == null)
            {
                return NotFound();
            }

            var trueFalseQuestion = await _context.TrueFalseQuestion.FindAsync(id);
            if (trueFalseQuestion == null)
            {
                return NotFound();
            }
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", trueFalseQuestion.ChapterId);
            return View(trueFalseQuestion);
        }

        // POST: TrueFalseQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorrectAnswer,Id,Text,Type,Difficulty,ChapterId")] TrueFalseQuestion trueFalseQuestion)
        {
            if (id != trueFalseQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trueFalseQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrueFalseQuestionExists(trueFalseQuestion.Id))
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
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", trueFalseQuestion.ChapterId);
            return View(trueFalseQuestion);
        }

        // GET: TrueFalseQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrueFalseQuestion == null)
            {
                return NotFound();
            }

            var trueFalseQuestion = await _context.TrueFalseQuestion
                .Include(t => t.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trueFalseQuestion == null)
            {
                return NotFound();
            }

            return View(trueFalseQuestion);
        }

        // POST: TrueFalseQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrueFalseQuestion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TrueFalseQuestion'  is null.");
            }
            var trueFalseQuestion = await _context.TrueFalseQuestion.FindAsync(id);
            if (trueFalseQuestion != null)
            {
                _context.TrueFalseQuestion.Remove(trueFalseQuestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrueFalseQuestionExists(int id)
        {
          return (_context.TrueFalseQuestion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
