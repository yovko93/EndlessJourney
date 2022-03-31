namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipRoomsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var shipRoomsList = new List<ShipRoom>()
            {
                new ShipRoom
                {
                    ShipId = 1,
                    RoomId = 1,
                },
                new ShipRoom
                {
                    ShipId = 1,
                    RoomId = 2,
                },
                new ShipRoom
                {
                    ShipId = 1,
                    RoomId = 3,
                },
                new ShipRoom
                {
                    ShipId = 1,
                    RoomId = 4,
                },
                new ShipRoom
                {
                    ShipId = 2,
                    RoomId = 1,
                },
                new ShipRoom
                {
                    ShipId = 2,
                    RoomId = 2,
                },
                new ShipRoom
                {
                    ShipId = 2,
                    RoomId = 3,
                },
                new ShipRoom
                {
                    ShipId = 2,
                    RoomId = 4,
                },
                new ShipRoom
                {
                    ShipId = 3,
                    RoomId = 1,
                },
                new ShipRoom
                {
                    ShipId = 3,
                    RoomId = 2,
                },
                new ShipRoom
                {
                    ShipId = 3,
                    RoomId = 3,
                },
                new ShipRoom
                {
                    ShipId = 3,
                    RoomId = 4,
                },
                new ShipRoom
                {
                    ShipId = 4,
                    RoomId = 1,
                },
                new ShipRoom
                {
                    ShipId = 4,
                    RoomId = 2,
                },
                new ShipRoom
                {
                    ShipId = 4,
                    RoomId = 3,
                },
                new ShipRoom
                {
                    ShipId = 4,
                    RoomId = 4,
                },
                new ShipRoom
                {
                    ShipId = 5,
                    RoomId = 1,
                },
                new ShipRoom
                {
                    ShipId = 5,
                    RoomId = 2,
                },
                new ShipRoom
                {
                    ShipId = 5,
                    RoomId = 3,
                },
                new ShipRoom
                {
                    ShipId = 5,
                    RoomId = 4,
                },
            };

            foreach (ShipRoom shipRoom in shipRoomsList)
            {
                var dbShipRoom = await dbContext.ShipRooms
                    .FirstOrDefaultAsync(x =>
                        x.ShipId == shipRoom.ShipId
                        && x.RoomId == shipRoom.RoomId);

                if (dbShipRoom == null)
                {
                    await dbContext.ShipRooms.AddAsync(shipRoom);
                }
            }
        }
    }
}
