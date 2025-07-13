using Microsoft.EntityFrameworkCore;
using CompleteProject.Models;

namespace CompleteProject.Data
{
    public class BugRepository : IBugRepository
    {
        private readonly ApplicationDbContext _context;

        public BugRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bug>> GetBugsAsync()
        {
            return await _context.Bugs.Include(b => b.AttachedBug).ToListAsync();
        }

        public async Task AddBugAsync(Bug bug)
        {
            await _context.Bugs.AddAsync(bug);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBugAsync(Bug bug)
        {
            _context.Bugs.Update(bug);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBugAsync(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug != null)
            {
                _context.Bugs.Remove(bug);
                await _context.SaveChangesAsync();
            }
        }
    }
}