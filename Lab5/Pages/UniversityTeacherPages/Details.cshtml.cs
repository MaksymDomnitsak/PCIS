using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.UniversityTeacherPages
{
    public class DetailsModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public DetailsModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

      public UniversityTeacher UniversityTeacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UniversityTeachers == null)
            {
                return NotFound();
            }

            var universityteacher = await _context.UniversityTeachers.FirstOrDefaultAsync(m => m.Id == id);
            if (universityteacher == null)
            {
                return NotFound();
            }
            else 
            {
                UniversityTeacher = universityteacher;
            }
            return Page();
        }
    }
}
