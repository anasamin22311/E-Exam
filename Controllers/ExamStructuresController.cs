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
    public class ExamStructuresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamStructuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExamStructures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExamStructure.Include(e => e.Chapter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExamStructures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamStructure == null)
            {
                return NotFound();
            }

            var examStructure = await _context.ExamStructure
                .Include(e => e.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examStructure == null)
            {
                return NotFound();
            }

            return View(examStructure);
        }

        // GET: ExamStructures/Create
        public IActionResult Create()
        {
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id");
            return View();
        }

        // POST: ExamStructures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalQuestions,MCQQuestions,TFQuestions,CategoryA,CategoryB,CategoryC,ChapterId")] ExamStructure examStructure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examStructure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", examStructure.ChapterId);
            return View(examStructure);
        }

        // GET: ExamStructures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamStructure == null)
            {
                return NotFound();
            }

            var examStructure = await _context.ExamStructure.FindAsync(id);
            if (examStructure == null)
            {
                return NotFound();
            }
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", examStructure.ChapterId);
            return View(examStructure);
        }

        // POST: ExamStructures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalQuestions,MCQQuestions,TFQuestions,CategoryA,CategoryB,CategoryC,ChapterId")] ExamStructure examStructure)
        {
            if (id != examStructure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examStructure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamStructureExists(examStructure.Id))
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
            ViewData["ChapterId"] = new SelectList(_context.Chapters, "Id", "Id", examStructure.ChapterId);
            return View(examStructure);
        }

        // GET: ExamStructures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamStructure == null)
            {
                return NotFound();
            }

            var examStructure = await _context.ExamStructure
                .Include(e => e.Chapter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examStructure == null)
            {
                return NotFound();
            }

            return View(examStructure);
        }

        // POST: ExamStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamStructure == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExamStructure'  is null.");
            }
            var examStructure = await _context.ExamStructure.FindAsync(id);
            if (examStructure != null)
            {
                _context.ExamStructure.Remove(examStructure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamStructureExists(int id)
        {
          return (_context.ExamStructure?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
