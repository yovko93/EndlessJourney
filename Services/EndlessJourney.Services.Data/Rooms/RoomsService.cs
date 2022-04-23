namespace EndlessJourney.Services.Data.Rooms
{
    using System.Collections.Generic;
    using System.Linq;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;

    public class RoomsService : IRoomsService
    {
        private readonly IDeletableEntityRepository<Room> roomsRepository;

        public RoomsService(
            IDeletableEntityRepository<Room> roomsRepository)
        {
            this.roomsRepository = roomsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.roomsRepository
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
