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
    public class QuestionResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionResults
        public async Task<IActionResult> Index()
        {
              return _context.QuestionResult != null ? 
                          View(await _context.QuestionResult.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuestionResult'  is null.");
        }

        // GET: QuestionResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionResult == null)
            {
                return NotFound();
            }

            var questionResult = await _context.QuestionResult
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionResult == null)
            {
                return NotFound();
            }

            return View(questionResult);
        }

        // GET: QuestionResults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorrectAnswers,WrongAnswers")] QuestionResult questionResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionResult);
        }

        // GET: QuestionResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestionResult == null)
            {
                return NotFound();
            }

            var questionResult = await _context.QuestionResult.FindAsync(id);
            if (questionResult == null)
            {
                return NotFound();
            }
            return View(questionResult);
        }

        // POST: QuestionResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorrectAnswers,WrongAnswers")] QuestionResult questionResult)
        {
            if (id != questionResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionResultExists(questionResult.Id))
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
            return View(questionResult);
        }

        // GET: QuestionResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestionResult == null)
            {
                return NotFound();
            }

            var questionResult = await _context.QuestionResult
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionResult == null)
            {
                return NotFound();
            }

            return View(questionResult);
        }

        // POST: QuestionResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestionResult == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuestionResult'  is null.");
            }
            var questionResult = await _context.QuestionResult.FindAsync(id);
            if (questionResult != null)
            {
                _context.QuestionResult.Remove(questionResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionResultExists(int id)
        {
          return (_context.QuestionResult?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
