namespace EndlessJourney.Services.Data.Destinations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDestinationsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage = 6);

        Task<int> GetCountAsync();
    }
}
