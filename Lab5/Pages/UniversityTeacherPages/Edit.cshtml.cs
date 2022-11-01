using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.UniversityTeacherPages
{
    public class EditModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public EditModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UniversityTeacher UniversityTeacher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UniversityTeachers == null)
            {
                return NotFound();
            }

            var universityteacher =  await _context.UniversityTeachers.FirstOrDefaultAsync(m => m.Id == id);
            if (universityteacher == null)
            {
                return NotFound();
            }
            UniversityTeacher = universityteacher;
           ViewData["FirstSubjectName"] = new SelectList(_context.Subjects, "Id", "Id");
           ViewData["PositionName"] = new SelectList(_context.Positions, "Id", "Id");
           ViewData["SecondSubjectName"] = new SelectList(_context.Subjects, "Id", "Id");
           ViewData["WorkPlace"] = new SelectList(_context.Workplaces, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UniversityTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityTeacherExists(UniversityTeacher.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UniversityTeacherExists(int id)
        {
          return _context.UniversityTeachers.Any(e => e.Id == id);
        }
    }
}
