using CompleteProject.Models;

namespace CompleteProject.Data
{
    public interface IBugRepository
    {
        Task<List<Bug>> GetBugsAsync();
        Task AddBugAsync(Bug bug);
        Task UpdateBugAsync(Bug bug);
        Task DeleteBugAsync(int id);
    }
}