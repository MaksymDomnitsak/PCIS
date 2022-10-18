using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class WorkplacesController : Controller
    {
        private readonly UniversityTeachersContext _context;

        public WorkplacesController(UniversityTeachersContext context)
        {
            _context = context;
        }

        // GET: Workplaces
        public async Task<IActionResult> Index()
        {
              return View(await _context.Workplaces.ToListAsync());
        }

        // GET: Workplaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Workplaces == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // GET: Workplaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workplaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workplace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workplace);
        }

        // GET: Workplaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Workplaces == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces.FindAsync(id);
            if (workplace == null)
            {
                return NotFound();
            }
            return View(workplace);
        }

        // POST: Workplaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Workplace workplace)
        {
            if (id != workplace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workplace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkplaceExists(workplace.Id))
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
            return View(workplace);
        }

        // GET: Workplaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Workplaces == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // POST: Workplaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workplaces == null)
            {
                return Problem("Entity set 'UniversityTeachersContext.Workplaces'  is null.");
            }
            var workplace = await _context.Workplaces.FindAsync(id);
            if (workplace != null)
            {
                _context.Workplaces.Remove(workplace);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkplaceExists(int id)
        {
          return _context.Workplaces.Any(e => e.Id == id);
        }
    }
}
