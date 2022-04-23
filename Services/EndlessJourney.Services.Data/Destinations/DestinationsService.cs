namespace EndlessJourney.Services.Data.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Destinations;
    using Microsoft.EntityFrameworkCore;

    using static EndlessJourney.Common.GlobalConstants.Destination;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public DestinationsService(
            IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.destinationsRepository = destinationsRepository;
        }

        public async Task CreateAsync(CreateDestinationInputModel destinationModel)
        {
            var isExist = this.destinationsRepository
                .AllAsNoTracking()
                .Any(x => x.StartPointId == destinationModel.StartPointId && x.EndPointId == destinationModel.EndPointId);

            if (isExist)
            {
                throw new Exception(DestinationAlreadyExist);
            }

            var destination = new Destination
            {
                Name = destinationModel.Name,
                Description = destinationModel.Description,
                StartPointId = destinationModel.StartPointId,
                EndPointId = destinationModel.EndPointId,
            };

            await this.destinationsRepository.AddAsync(destination);
            await this.destinationsRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.destinationsRepository
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

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        => await this.destinationsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<TModel>()
                .ToListAsync();

        public async Task<int> GetCountAsync()
           => await this.destinationsRepository
               .AllAsNoTracking()
               .CountAsync();
    }
}
