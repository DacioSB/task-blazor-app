using CompleteProject.Data;
using CompleteProject.Models;

namespace CompleteProject.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<Feature>> GetFeaturesAsync()
        {
            return await _featureRepository.GetFeaturesAsync();
        }

        public async Task AddFeatureAsync(Feature feature)
        {
            await _featureRepository.AddFeatureAsync(feature);
        }

        public async Task UpdateFeatureAsync(Feature feature)
        {
            await _featureRepository.UpdateFeatureAsync(feature);
        }

        public async Task DeleteFeatureAsync(int id)
        {
            await _featureRepository.DeleteFeatureAsync(id);
        }
    }
}