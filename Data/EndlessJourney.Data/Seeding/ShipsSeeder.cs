namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var shipsList = new List<Ship>()
            {
                new Ship
                {
                    Name = "Queen Mary 2",
                    Description = "Queen Mary 2 is a remarkable flagship, her style and elegance are legendary. Above all, it‘s the space she offers and the luxury for you to do as little or as much as you wish which sets her apart.",
                    Capacity = 300,
                    Crew = 158,
                    Length = 1132,
                    Image = new Image
                            {
                                PathName = "/images/CaribbeanPrincess.jpg",
                                Extension = "jpg",
                            },
                },
                new Ship
                {
                    Name = "Columbus 2",
                    Description = "Join us on Columbus 2 and immerse yourself in her evocative art deco elegance. Our newest Columbus exudes style and has an especially refined feel. Prepare yourself for a truly remarkable voyage.",
                    Capacity = 500,
                    Crew = 198,
                    Length = 1236,
                    Image = new Image
                            {
                                PathName = "/images/SunPrincess.jpg",
                                Extension = "jpg",
                            },
                },
                new Ship
                {
                    Name = "Fantasy",
                    Description = "Specially designed to capture the heart of discovery, Fantasy features several destination immersion experiences right from her beautiful decks down to the exotic ports-of-call.",
                    Capacity = 700,
                    Crew = 242,
                    Length = 1338,
                    Image = new Image
                            {
                                PathName = "/images/Fantasy.jpg",
                                Extension = "jpg",
                            },
                },
                new Ship
                {
                    Name = "Sun Princess",
                    Description = "You’ll be thrilled with the star of the Oceans show, the Sun Princess, which will sail you far away to the most exciting and engaging destinations and cultures.",
                    Capacity = 800,
                    Crew = 274,
                    Length = 1272,
                    Image = new Image
                            {
                                PathName = "/images/Columbus2.jpg",
                                Extension = "jpg",
                            },
                },
                new Ship
                {
                    Name = "Caribbean Princess",
                    Description = "Caribbean Princess will delight you with her special appeal, where elegance and unique features combine seamlessly with outstanding hospitality. You’ll discover an extraordinary way to see the world.",
                    Capacity = 1000,
                    Crew = 383,
                    Length = 1522,
                    Image = new Image
                            {
                                PathName = "/images/QueenMary2.jpg",
                                Extension = "jpg",
                            },
                },
            };

            foreach (Ship ship in shipsList)
            {
                var dbShip = await dbContext.Ships
                    .FirstOrDefaultAsync(x => x.Name == ship.Name);

                if (dbShip == null)
                {
                    await dbContext.Ships.AddAsync(ship);
                }
            }
        }
    }
}
