using CompleteProject.Models;

namespace CompleteProject.Data
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetFeaturesAsync();
        Task AddFeatureAsync(Feature feature);
        Task UpdateFeatureAsync(Feature feature);
        Task DeleteFeatureAsync(int id);
    }
}