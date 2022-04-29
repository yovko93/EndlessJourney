namespace EndlessJourney.Services.Data.Destinations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.ViewModels.Destinations;

    public interface IDestinationsService
    {
        Task CreateAsync(CreateDestinationInputModel destinationModel);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        public DestinationQueryServiceModel All(
            string endPoint = null,
            string searchTerm = null,
            DestinationSorting sorting = DestinationSorting.DateCreated,
            int currentPage = 1,
            int destinationsPerPage = int.MaxValue);

        public IEnumerable<string> AllEndPoints();

        Task<int> GetCountAsync();
    }
}
