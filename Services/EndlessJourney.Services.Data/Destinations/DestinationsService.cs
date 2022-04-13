namespace EndlessJourney.Services.Data.Destinations
{
    using System.Collections.Generic;
    using System.Linq;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;

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
    }
}
