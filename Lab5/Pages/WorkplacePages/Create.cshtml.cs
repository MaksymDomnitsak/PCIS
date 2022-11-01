using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.WorkplacePages
{
    public class CreateModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public CreateModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Workplace Workplace { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workplaces.Add(Workplace);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
