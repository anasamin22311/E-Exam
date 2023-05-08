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
    public class QuestionStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionStatistics
        public async Task<IActionResult> Index()
        {
              return _context.QuestionStatistics != null ? 
                          View(await _context.QuestionStatistics.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuestionStatistics'  is null.");
        }

        // GET: QuestionStatistics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionStatistics == null)
            {
                return NotFound();
            }

            var questionStatistics = await _context.QuestionStatistics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionStatistics == null)
            {
                return NotFound();
            }

            return View(questionStatistics);
        }

        // GET: QuestionStatistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionStatistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorrectAnswers,WrongAnswers")] QuestionStatistics questionStatistics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionStatistics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionStatistics);
        }

        // GET: QuestionStatistics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestionStatistics == null)
            {
                return NotFound();
            }

            var questionStatistics = await _context.QuestionStatistics.FindAsync(id);
            if (questionStatistics == null)
            {
                return NotFound();
            }
            return View(questionStatistics);
        }

        // POST: QuestionStatistics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorrectAnswers,WrongAnswers")] QuestionStatistics questionStatistics)
        {
            if (id != questionStatistics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionStatistics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionStatisticsExists(questionStatistics.Id))
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
            return View(questionStatistics);
        }

        // GET: QuestionStatistics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestionStatistics == null)
            {
                return NotFound();
            }

            var questionStatistics = await _context.QuestionStatistics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionStatistics == null)
            {
                return NotFound();
            }

            return View(questionStatistics);
        }

        // POST: QuestionStatistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestionStatistics == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuestionStatistics'  is null.");
            }
            var questionStatistics = await _context.QuestionStatistics.FindAsync(id);
            if (questionStatistics != null)
            {
                _context.QuestionStatistics.Remove(questionStatistics);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionStatisticsExists(int id)
        {
          return (_context.QuestionStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
