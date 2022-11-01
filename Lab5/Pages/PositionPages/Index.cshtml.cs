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
    public class IndexModel : PageModel
    {
        private readonly Lab5.Data.UniversityTeachersContext _context;

        public IndexModel(Lab5.Data.UniversityTeachersContext context)
        {
            _context = context;
        }

        public IList<Position> Position { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Positions != null)
            {
                Position = await _context.Positions.ToListAsync();
            }
        }
    }
}
