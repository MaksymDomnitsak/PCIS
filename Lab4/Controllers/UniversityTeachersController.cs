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
    public class UniversityTeachersController : Controller
    {
        private readonly UniversityTeachersContext _context;

        public UniversityTeachersController(UniversityTeachersContext context)
        {
            _context = context;
        }

        // GET: UniversityTeachers
        public async Task<IActionResult> Index()
        {
            var universityTeachersContext = _context.UniversityTeachers.Include(u => u.FirstSubjectNameNavigation).Include(u => u.PositionNameNavigation).Include(u => u.SecondSubjectNameNavigation).Include(u => u.WorkPlaceNavigation);
            return View(await universityTeachersContext.ToListAsync());
        }

        // GET: UniversityTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniversityTeachers == null)
            {
                return NotFound();
            }

            var universityTeacher = await _context.UniversityTeachers
                .Include(u => u.FirstSubjectNameNavigation)
                .Include(u => u.PositionNameNavigation)
                .Include(u => u.SecondSubjectNameNavigation)
                .Include(u => u.WorkPlaceNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityTeacher == null)
            {
                return NotFound();
            }

            return View(universityTeacher);
        }

        // GET: UniversityTeachers/Create
        public IActionResult Create()
        {
            ViewData["FirstSubjectName"] = new SelectList(_context.Subjects, "Id", "Id");
            ViewData["PositionName"] = new SelectList(_context.Positions, "Id", "Id");
            ViewData["SecondSubjectName"] = new SelectList(_context.Subjects, "Id", "Id");
            ViewData["WorkPlace"] = new SelectList(_context.Workplaces, "Id", "Id");
            return View();
        }

        // POST: UniversityTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PatronymicName,WorkPlace,PositionName,FirstSubjectName,SecondSubjectName,PositionHourlyRate,CountReadHours,HomeAddress,Characteristics")] UniversityTeacher universityTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirstSubjectName"] = new SelectList(_context.Subjects, "Id", "Id", universityTeacher.FirstSubjectName);
            ViewData["PositionName"] = new SelectList(_context.Positions, "Id", "Id", universityTeacher.PositionName);
            ViewData["SecondSubjectName"] = new SelectList(_context.Subjects, "Id", "Id", universityTeacher.SecondSubjectName);
            ViewData["WorkPlace"] = new SelectList(_context.Workplaces, "Id", "Id", universityTeacher.WorkPlace);
            return View(universityTeacher);
        }

        // GET: UniversityTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniversityTeachers == null)
            {
                return NotFound();
            }

            var universityTeacher = await _context.UniversityTeachers.FindAsync(id);
            if (universityTeacher == null)
            {
                return NotFound();
            }
            ViewData["FirstSubjectName"] = new SelectList(_context.Subjects, "Id", "Id", universityTeacher.FirstSubjectName);
            ViewData["PositionName"] = new SelectList(_context.Positions, "Id", "Id", universityTeacher.PositionName);
            ViewData["SecondSubjectName"] = new SelectList(_context.Subjects, "Id", "Id", universityTeacher.SecondSubjectName);
            ViewData["WorkPlace"] = new SelectList(_context.Workplaces, "Id", "Id", universityTeacher.WorkPlace);
            return View(universityTeacher);
        }

        // POST: UniversityTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PatronymicName,WorkPlace,PositionName,FirstSubjectName,SecondSubjectName,PositionHourlyRate,CountReadHours,HomeAddress,Characteristics")] UniversityTeacher universityTeacher)
        {
            if (id != universityTeacher.Id)
            {
                return NotFound();
            }
            TryValidateModel(universityTeacher);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityTeacherExists(universityTeacher.Id))
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
            ViewData["FirstSubjectName"] = new SelectList(_context.Subjects, "Id", "Id", universityTeacher.FirstSubjectName);
            ViewData["PositionName"] = new SelectList(_context.Positions, "Id", "Id", universityTeacher.PositionName);
            ViewData["SecondSubjectName"] = new SelectList(_context.Subjects, "Id", "Id", universityTeacher.SecondSubjectName);
            ViewData["WorkPlace"] = new SelectList(_context.Workplaces, "Id", "Id", universityTeacher.WorkPlace);
            return View(universityTeacher);
        }

        // GET: UniversityTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniversityTeachers == null)
            {
                return NotFound();
            }

            var universityTeacher = await _context.UniversityTeachers
                .Include(u => u.FirstSubjectNameNavigation)
                .Include(u => u.PositionNameNavigation)
                .Include(u => u.SecondSubjectNameNavigation)
                .Include(u => u.WorkPlaceNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityTeacher == null)
            {
                return NotFound();
            }

            return View(universityTeacher);
        }

        // POST: UniversityTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniversityTeachers == null)
            {
                return Problem("Entity set 'UniversityTeachersContext.UniversityTeachers'  is null.");
            }
            var universityTeacher = await _context.UniversityTeachers.FindAsync(id);
            if (universityTeacher != null)
            {
                _context.UniversityTeachers.Remove(universityTeacher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityTeacherExists(int id)
        {
          return _context.UniversityTeachers.Any(e => e.Id == id);
        }
    }
}
