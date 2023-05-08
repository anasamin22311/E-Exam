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
    public class ExamResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExamResults
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExamResult.Include(e => e.Exam);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExamResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamResult == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResult
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // GET: ExamResults/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id");
            return View();
        }

        // POST: ExamResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,ExamId,Score,Timestamp")] ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", examResult.ExamId);
            return View(examResult);
        }

        // GET: ExamResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamResult == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResult.FindAsync(id);
            if (examResult == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", examResult.ExamId);
            return View(examResult);
        }

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,ExamId,Score,Timestamp")] ExamResult examResult)
        {
            if (id != examResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamResultExists(examResult.Id))
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
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", examResult.ExamId);
            return View(examResult);
        }

        // GET: ExamResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamResult == null)
            {
                return NotFound();
            }

            var examResult = await _context.ExamResult
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamResult == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExamResult'  is null.");
            }
            var examResult = await _context.ExamResult.FindAsync(id);
            if (examResult != null)
            {
                _context.ExamResult.Remove(examResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamResultExists(int id)
        {
          return (_context.ExamResult?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
