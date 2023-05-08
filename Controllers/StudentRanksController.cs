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
    public class StudentRanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentRanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentRanks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentRank.Include(s => s.Level).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentRank == null)
            {
                return NotFound();
            }

            var studentRank = await _context.StudentRank
                .Include(s => s.Level)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRank == null)
            {
                return NotFound();
            }

            return View(studentRank);
        }

        // GET: StudentRanks/Create
        public IActionResult Create()
        {
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: StudentRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rank,UserId,LevelId")] StudentRank studentRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Id", studentRank.LevelId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", studentRank.UserId);
            return View(studentRank);
        }

        // GET: StudentRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentRank == null)
            {
                return NotFound();
            }

            var studentRank = await _context.StudentRank.FindAsync(id);
            if (studentRank == null)
            {
                return NotFound();
            }
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Id", studentRank.LevelId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", studentRank.UserId);
            return View(studentRank);
        }

        // POST: StudentRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rank,UserId,LevelId")] StudentRank studentRank)
        {
            if (id != studentRank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentRankExists(studentRank.Id))
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
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Id", studentRank.LevelId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", studentRank.UserId);
            return View(studentRank);
        }

        // GET: StudentRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentRank == null)
            {
                return NotFound();
            }

            var studentRank = await _context.StudentRank
                .Include(s => s.Level)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRank == null)
            {
                return NotFound();
            }

            return View(studentRank);
        }

        // POST: StudentRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentRank == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentRank'  is null.");
            }
            var studentRank = await _context.StudentRank.FindAsync(id);
            if (studentRank != null)
            {
                _context.StudentRank.Remove(studentRank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentRankExists(int id)
        {
          return (_context.StudentRank?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
