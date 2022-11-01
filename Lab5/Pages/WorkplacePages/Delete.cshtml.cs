using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.WorkplacePages
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public DeleteModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Workplace Workplace { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workplaces == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces.FirstOrDefaultAsync(m => m.Id == id);

            if (workplace == null)
            {
                return NotFound();
            }
            else 
            {
                Workplace = workplace;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Workplaces == null)
            {
                return NotFound();
            }
            var workplace = await _context.Workplaces.FindAsync(id);

            if (workplace != null)
            {
                Workplace = workplace;
                _context.Workplaces.Remove(Workplace);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
