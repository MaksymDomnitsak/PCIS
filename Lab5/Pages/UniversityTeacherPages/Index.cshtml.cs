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
    public class IndexModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public IndexModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        public IList<UniversityTeacher> UniversityTeacher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UniversityTeachers != null)
            {
                UniversityTeacher = await _context.UniversityTeachers
                .Include(u => u.FirstSubjectNameNavigation)
                .Include(u => u.PositionNameNavigation)
                .Include(u => u.SecondSubjectNameNavigation)
                .Include(u => u.WorkPlaceNavigation).ToListAsync();
            }
        }
    }
}
