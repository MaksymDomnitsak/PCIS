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

namespace Lab5.Pages.WorkplacePages
{
    public class EditModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public EditModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workplace Workplace { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workplaces == null)
            {
                return NotFound();
            }

            var workplace =  await _context.Workplaces.FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }
            Workplace = workplace;
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

            _context.Attach(Workplace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkplaceExists(Workplace.Id))
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

        private bool WorkplaceExists(int id)
        {
          return _context.Workplaces.Any(e => e.Id == id);
        }
    }
}
