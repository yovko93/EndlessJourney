namespace EndlessJourney.Services.Data.Destinations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public DestinationsService(
            IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.destinationsRepository = destinationsRepository;
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

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage = 6)
        => await this.destinationsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<TModel>()
                .ToListAsync();

        public async Task<int> GetCountAsync()
           => await this.destinationsRepository
               .AllAsNoTracking()
               .CountAsync();
    }
}
