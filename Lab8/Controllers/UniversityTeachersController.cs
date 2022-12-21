using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab8;

namespace Lab8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityTeachersController : ControllerBase
    {
        private readonly UniversityTeachersContext _context;

        public UniversityTeachersController(UniversityTeachersContext context)
        {
            _context = context;
        }

        // GET: api/UniversityTeachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityTeacher>>> GetUniversityTeachers()
        {
            return await _context.UniversityTeachers.ToListAsync();
        }

        // GET: api/UniversityTeachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityTeacher>> GetUniversityTeacher(int id)
        {
            var universityTeacher = await _context.UniversityTeachers.FindAsync(id);

            if (universityTeacher == null)
            {
                return NotFound();
            }

            return universityTeacher;
        }

        // PUT: api/UniversityTeachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversityTeacher(int id, UniversityTeacher universityTeacher)
        {
            if (id != universityTeacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(universityTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityTeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UniversityTeachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UniversityTeacher>> PostUniversityTeacher(UniversityTeacher universityTeacher)
        {
            _context.UniversityTeachers.Add(universityTeacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversityTeacher", new { id = universityTeacher.Id }, universityTeacher);
        }

        // DELETE: api/UniversityTeachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversityTeacher(int id)
        {
            var universityTeacher = await _context.UniversityTeachers.FindAsync(id);
            if (universityTeacher == null)
            {
                return NotFound();
            }

            _context.UniversityTeachers.Remove(universityTeacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversityTeacherExists(int id)
        {
            return _context.UniversityTeachers.Any(e => e.Id == id);
        }
    }
}
