namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TripsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var tripsList = new List<Trip>()
            {
                new Trip
                {
                    StartDate = DateTime.Parse("2022/05/15"),
                    EndDate = DateTime.Parse("2022/06/03"),
                    Price = 4300,
                    Discount = 5,
                    DestinationId = 1,
                    ShipId = 1,
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/09/24"),
                    EndDate = DateTime.Parse("2022/09/30"),
                    Price = 2350,
                    Discount = 10,
                    DestinationId = 4,
                    ShipId = 2,
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/10/13"),
                    EndDate = DateTime.Parse("2022/11/01"),
                    Price = 3600,
                    DestinationId = 5,
                    ShipId = 3,
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/11/03"),
                    EndDate = DateTime.Parse("2022/12/03"),
                    Price = 5210,
                    Discount = 15,
                    DestinationId = 6,
                    ShipId = 4,
                },
            };

            foreach (Trip trip in tripsList)
            {
                var dbTrip = await dbContext.Trips
                    .FirstOrDefaultAsync(x =>
                        x.ShipId == trip.ShipId
                        && x.DestinationId == trip.DestinationId
                        && x.StartDate == trip.StartDate);

                if (dbTrip == null)
                {
                    await dbContext.Trips.AddAsync(trip);
                }
            }
        }
    }
}
