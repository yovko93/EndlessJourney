namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RoomsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roomsList = new List<Room>()
            {
                new Room
                {
                    Name = "Interior",
                    Description = "This is an affordable way to cruise without leaving out the comfort or convenience! Great for curling up after a long day of fun.",
                    Stars = 3,
                },
                new Room
                {
                    Name = "Ocean View",
                    Description = "A picture window gives you views of scenery you won’t find anywhere on land, all from the comfort of your stateroom.",
                    Stars = 5,
                },
                new Room
                {
                    Name = "Balcony",
                    Description = "Balcony staterooms were designed for maximum sea breeze and the most stunning views, so look to a balcony if you’re looking to cruise aboard Carnival Miracle. Any time you’re in your room, you’re just steps away from your own personal outdoor oasis, featuring the sort of sea view you can also feel.",
                    Stars = 4,
                },
                new Room
                {
                    Name = "Suite",
                    Description = "Cruise suite accommodations are premium grades cabins. They are usually larger in comparison to balcony staterooms and feature more amenities.",
                    Stars = 5,
                },
            };

            foreach (Room room in roomsList)
            {
                var dbRoom = await dbContext.Rooms
                    .FirstOrDefaultAsync(x => x.Name == room.Name);

                if (dbRoom == null)
                {
                    await dbContext.Rooms.AddAsync(room);
                }
            }
        }
    }
}
