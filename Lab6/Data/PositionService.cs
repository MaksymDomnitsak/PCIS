using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public class PositionService : IPositionService
    {
        private readonly UniversityTeachersContext _context;
        private readonly NavigationManager _navigationManager;

        public List<Position> Positions { get; set; } = new List<Position>();

        public PositionService(UniversityTeachersContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public async Task CreatePosition(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("positions");
        }

        public async Task DeleteObject(int id)
        {
            var dbPos = await _context.Positions.FindAsync(id);
            if (dbPos == null)
                throw new Exception("No position here.");

            _context.Positions.Remove(dbPos);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("positions");
        }

        public async Task<Position> GetSinglePosition(int id)
        {
            var pos = await _context.Positions.FindAsync(id);
            if (pos == null)
                throw new Exception("No position here.");
            return pos;
        }

        public async Task LoadObjects()
        {
            Positions = await _context.Positions.ToListAsync();
        }

        public async Task UpdatePosition(Position position, int id)
        {
            var dbPos = await _context.Positions.FindAsync(id);
            if (dbPos == null)
                throw new Exception("No position here.");

            dbPos.Name = position.Name;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("positions");
        }
    }
}
