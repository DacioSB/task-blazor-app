using CompleteProject.Models;

namespace CompleteProject.Services
{
    public interface IFeatureService
    {
        Task<List<Feature>> GetFeaturesAsync();
        Task AddFeatureAsync(Feature feature);
        Task UpdateFeatureAsync(Feature feature);
        Task DeleteFeatureAsync(int id);
    }
}