namespace EndlessJourney.Services.Data.Trips
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Web.ViewModels.Trips;

    public interface ITripsService
    {
        Task CreateAsync(CreateTripInputModel tripModel, string imagePath);

        Task UpdateAsync(string id, UpdateTripInputModel tripModel);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        int GetCount();

        Task<IEnumerable<TModel>> GetRandomAsync<TModel>(int count);

        Task DeleteAsync(string id);
    }
}
