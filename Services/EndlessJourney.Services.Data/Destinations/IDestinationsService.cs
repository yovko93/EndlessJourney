namespace EndlessJourney.Services.Data.Destinations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Web.ViewModels.Destinations;

    public interface IDestinationsService
    {
        Task CreateAsync(CreateDestinationInputModel destinationModel);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<int> GetCountAsync();
    }
}
