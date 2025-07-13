using CompleteProject.Models;
using CompleteProject.Services;

namespace CompleteProject.ViewModels
{
    public class BugListViewModel
    {
        private readonly IBugService _bugService;
        public List<Bug> Bugs { get; private set; }

        public BugListViewModel(IBugService bugService)
        {
            _bugService = bugService;
            Bugs = new List<Bug>();
        }

        public async Task LoadBugsAsync()
        {
            Bugs = await _bugService.GetBugsAsync();
        }

        public async Task AddBugAsync(Bug bug)
        {
            await _bugService.AddBugAsync(bug);
            await LoadBugsAsync();
        }

        public async Task UpdateBugAsync(Bug bug)
        {
            await _bugService.UpdateBugAsync(bug);
            await LoadBugsAsync();
        }

        public async Task DeleteBugAsync(int id)
        {
            await _bugService.DeleteBugAsync(id);
            await LoadBugsAsync();
        }
    }
}