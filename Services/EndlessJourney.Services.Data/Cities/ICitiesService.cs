namespace EndlessJourney.Services.Data.Cities
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Web.ViewModels.Cities;

    public interface ICitiesService
    {
        Task CreateAsync(CreateCityInputModel cityModel);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<int> GetCountAsync();

        Task UpdateAsync(int id, EditCityInputModel cityModel);
    }
}
