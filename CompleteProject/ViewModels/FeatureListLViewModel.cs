using CompleteProject.Models;
using CompleteProject.Services;

namespace CompleteProject.ViewModels
{
    public class FeatureListViewModel
    {
        private readonly IFeatureService _featureService;
        public List<Feature> Features { get; private set; }

        public FeatureListViewModel(IFeatureService featureService)
        {
            _featureService = featureService;
            Features = new List<Feature>();
        }

        public async Task LoadFeaturesAsync()
        {
            Features = await _featureService.GetFeaturesAsync();
        }

        public async Task AddFeatureAsync(Feature feature)
        {
            await _featureService.AddFeatureAsync(feature);
            await LoadFeaturesAsync();
        }

        public async Task UpdateFeatureAsync(Feature feature)
        {
            await _featureService.UpdateFeatureAsync(feature);
            await LoadFeaturesAsync();
        }

        public async Task DeleteFeatureAsync(int id)
        {
            await _featureService.DeleteFeatureAsync(id);
            await LoadFeaturesAsync();
        }
    }
}