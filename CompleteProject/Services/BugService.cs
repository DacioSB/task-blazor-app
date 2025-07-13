using CompleteProject.Data;
using CompleteProject.Models;

namespace CompleteProject.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;

        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public async Task<List<Bug>> GetBugsAsync()
        {
            return await _bugRepository.GetBugsAsync();
        }

        public async Task AddBugAsync(Bug bug)
        {
            await _bugRepository.AddBugAsync(bug);
        }

        public async Task UpdateBugAsync(Bug bug)
        {
            await _bugRepository.UpdateBugAsync(bug);
        }

        public async Task DeleteBugAsync(int id)
        {
            await _bugRepository.DeleteBugAsync(id);
        }
    }
}