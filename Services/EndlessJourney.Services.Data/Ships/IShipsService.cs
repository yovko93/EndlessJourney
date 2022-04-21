namespace EndlessJourney.Services.Data.Ships
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShipsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<int> GetCountAsync();
    }
}
