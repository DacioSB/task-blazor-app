using CompleteProject.Models;

namespace CompleteProject.Services
{
    public interface IBugService
    {
        Task<List<Bug>> GetBugsAsync();
        Task AddBugAsync(Bug bug);
        Task UpdateBugAsync(Bug bug);
        Task DeleteBugAsync(int id);
    }
}