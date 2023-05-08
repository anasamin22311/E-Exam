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
    public class MCQQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MCQQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MCQQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MCQQuestion.Include(m => m.Chapter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MCQQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MCQQuestion == null)
            {
                return NotFound();
            }

            var mCQQuestion = await _context.MCQQuestion
                .Include(m => m.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mCQQuestion == null)
            {
                return NotFound();
            }

            return View(mCQQuestion);
        }

        // GET: MCQQuestions/Create
        public IActionResult Create()
        {
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id");
            return View();
        }

        // POST: MCQQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorrectAnswer,Choices,Id,Text,Type,Difficulty,ChapterId")] MCQQuestion mCQQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mCQQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", mCQQuestion.ChapterId);
            return View(mCQQuestion);
        }

        // GET: MCQQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MCQQuestion == null)
            {
                return NotFound();
            }

            var mCQQuestion = await _context.MCQQuestion.FindAsync(id);
            if (mCQQuestion == null)
            {
                return NotFound();
            }
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", mCQQuestion.ChapterId);
            return View(mCQQuestion);
        }

        // POST: MCQQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorrectAnswer,Choices,Id,Text,Type,Difficulty,ChapterId")] MCQQuestion mCQQuestion)
        {
            if (id != mCQQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mCQQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MCQQuestionExists(mCQQuestion.Id))
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
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", mCQQuestion.ChapterId);
            return View(mCQQuestion);
        }

        // GET: MCQQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MCQQuestion == null)
            {
                return NotFound();
            }

            var mCQQuestion = await _context.MCQQuestion
                .Include(m => m.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mCQQuestion == null)
            {
                return NotFound();
            }

            return View(mCQQuestion);
        }

        // POST: MCQQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MCQQuestion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MCQQuestion'  is null.");
            }
            var mCQQuestion = await _context.MCQQuestion.FindAsync(id);
            if (mCQQuestion != null)
            {
                _context.MCQQuestion.Remove(mCQQuestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MCQQuestionExists(int id)
        {
          return (_context.MCQQuestion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
