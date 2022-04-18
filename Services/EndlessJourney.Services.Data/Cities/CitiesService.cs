﻿namespace EndlessJourney.Services.Data.Cities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Cities;
    using Microsoft.EntityFrameworkCore;

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
            var city = new City
            {
                Name = cityModel.Name,
                State = cityModel.State,
                ImageUrl = cityModel.ImageUrl,
                CountryId = cityModel.CountryId,
            };

            await this.citiesRepository.AddAsync(city);
            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage = 6)
            => await this.citiesRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<TModel>()
                .ToListAsync();

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
            city.State = cityModel.State;
            city.ImageUrl = cityModel.ImageUrl;
            city.CountryId = cityModel.CountryId;

            await this.citiesRepository.SaveChangesAsync();
        }
    }
}
