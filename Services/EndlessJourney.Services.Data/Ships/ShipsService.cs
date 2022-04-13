namespace EndlessJourney.Services.Data.Ships
{
    using System.Collections.Generic;
    using System.Linq;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;

    public class ShipsService : IShipsService
    {
        private readonly IDeletableEntityRepository<Ship> shipsRepository;

        public ShipsService(
            IDeletableEntityRepository<Ship> shipsRepository)
        {
            this.shipsRepository = shipsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.shipsRepository
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
