namespace EndlessJourney.Services.Data.Ships
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.shipsRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(int id)
             => await this.shipsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task<int> GetCountAsync()
          => await this.shipsRepository
              .AllAsNoTracking()
              .CountAsync();
    }
}
