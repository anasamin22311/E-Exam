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
    public class SubjectProfessorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectProfessorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubjectProfessors
        public async Task<IActionResult> Index()
        {
              return _context.SubjectProfessor != null ? 
                          View(await _context.SubjectProfessor.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SubjectProfessor'  is null.");
        }

        // GET: SubjectProfessors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubjectProfessor == null)
            {
                return NotFound();
            }

            var subjectProfessor = await _context.SubjectProfessor
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subjectProfessor == null)
            {
                return NotFound();
            }

            return View(subjectProfessor);
        }

        // GET: SubjectProfessors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectProfessors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,ProfessorId")] SubjectProfessor subjectProfessor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectProfessor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectProfessor);
        }

        // GET: SubjectProfessors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubjectProfessor == null)
            {
                return NotFound();
            }

            var subjectProfessor = await _context.SubjectProfessor.FindAsync(id);
            if (subjectProfessor == null)
            {
                return NotFound();
            }
            return View(subjectProfessor);
        }

        // POST: SubjectProfessors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,ProfessorId")] SubjectProfessor subjectProfessor)
        {
            if (id != subjectProfessor.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectProfessor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectProfessorExists(subjectProfessor.SubjectId))
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
            return View(subjectProfessor);
        }

        // GET: SubjectProfessors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubjectProfessor == null)
            {
                return NotFound();
            }

            var subjectProfessor = await _context.SubjectProfessor
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subjectProfessor == null)
            {
                return NotFound();
            }

            return View(subjectProfessor);
        }

        // POST: SubjectProfessors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubjectProfessor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubjectProfessor'  is null.");
            }
            var subjectProfessor = await _context.SubjectProfessor.FindAsync(id);
            if (subjectProfessor != null)
            {
                _context.SubjectProfessor.Remove(subjectProfessor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectProfessorExists(int id)
        {
          return (_context.SubjectProfessor?.Any(e => e.SubjectId == id)).GetValueOrDefault();
        }
    }
}
