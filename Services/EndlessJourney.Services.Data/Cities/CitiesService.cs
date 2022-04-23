namespace EndlessJourney.Services.Data.Cities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Cities;
    using Microsoft.EntityFrameworkCore;

    using static EndlessJourney.Common.GlobalConstants.City;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(
            IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task CreateAsync(CreateCityInputModel cityModel)
        {
            var isExist = this.citiesRepository
                .AllAsNoTracking()
                .Any(x => x.Name == cityModel.Name && x.CountryId == cityModel.CountryId);

            if (isExist)
            {
                throw new Exception(CityAlreadyExist);
            }

            var city = new City
            {
                Name = cityModel.Name,
                Description = cityModel.Description,
                State = cityModel.State,
                ImageUrl = cityModel.ImageUrl,
                CountryId = cityModel.CountryId,
            };

            await this.citiesRepository.AddAsync(city);
            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.citiesRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<TModel>()
                .ToListAsync();

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.citiesRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id)
             => await this.citiesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task<int> GetCountAsync()
              => await this.citiesRepository
               .AllAsNoTracking()
               .CountAsync();

        public async Task UpdateAsync(int id, EditCityInputModel cityModel)
        {
            var city = this.citiesRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            city.Name = cityModel.Name;
            city.Description = cityModel.Description;
            city.State = cityModel.State;
            city.ImageUrl = cityModel.ImageUrl;
            city.CountryId = cityModel.CountryId;

            await this.citiesRepository.SaveChangesAsync();
        }
    }
}
