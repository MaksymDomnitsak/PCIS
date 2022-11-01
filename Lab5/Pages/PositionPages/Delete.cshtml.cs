using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.PositionPages
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public DeleteModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions.FirstOrDefaultAsync(m => m.Id == id);

            if (position == null)
            {
                return NotFound();
            }
            else 
            {
                Position = position;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }
            var position = await _context.Positions.FindAsync(id);

            if (position != null)
            {
                Position = position;
                _context.Positions.Remove(Position);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
