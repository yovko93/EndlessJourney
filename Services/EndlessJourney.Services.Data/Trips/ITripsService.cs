namespace EndlessJourney.Services.Data.Trips
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Web.ViewModels.Trips;

    public interface ITripsService
    {
        Task CreateAsync(CreateTripInputModel tripModel, string imagePath);

        Task UpdateAsync(string id, EditTripInputModel tripModel);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage = 6);

        Task<int> GetCountAsync();

        Task<IEnumerable<TModel>> GetRandomAsync<TModel>(int count);

        Task DeleteAsync(string id);
    }
}
