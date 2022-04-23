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
                    Price = 2300,
                    Discount = 5,
                    DestinationId = 1,
                    ShipId = 1,
                    Images = new List<Image>()
                    {
                        new Image
                        {
                            PathName = "/images/trips/istockphoto-148543868-612x612.jpg",
                            Extension = "jpg",
                        },
                    },
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/06/23"),
                    EndDate = DateTime.Parse("2022/07/03"),
                    Price = 1050,
                    Discount = 5,
                    DestinationId = 2,
                    ShipId = 2,
                    Images = new List<Image>()
                    {
                        new Image
                        {
                            PathName = "/images/trips/istockphoto-509846884-612x612.jpg",
                            Extension = "jpg",
                        },
                    },
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/04/16"),
                    EndDate = DateTime.Parse("2022/04/25"),
                    Price = 1510,
                    Discount = 25,
                    DestinationId = 3,
                    ShipId = 3,
                    Images = new List<Image>()
                    {
                        new Image
                        {
                            TripId = null,
                            PathName = "/images/trips/istockphoto-636665220-612x612.jpg",
                            Extension = "jpg",
                        },
                        new Image
                        {
                            TripId = null,
                            PathName = "/images/trips/istockphoto-1192581562-612x612.jpg",
                            Extension = "jpg",
                        },
                    },
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/09/24"),
                    EndDate = DateTime.Parse("2022/09/30"),
                    Price = 1350,
                    Discount = 10,
                    DestinationId = 4,
                    ShipId = 2,
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/10/13"),
                    EndDate = DateTime.Parse("2022/11/01"),
                    Price = 1600,
                    DestinationId = 5,
                    ShipId = 3,
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/11/03"),
                    EndDate = DateTime.Parse("2022/12/03"),
                    Price = 2210,
                    Discount = 15,
                    DestinationId = 6,
                    ShipId = 4,
                },
                new Trip
                {
                    StartDate = DateTime.Parse("2022/03/03"),
                    EndDate = DateTime.Parse("2022/03/09"),
                    Price = 1210,
                    Discount = 25,
                    DestinationId = 7,
                    ShipId = 5,
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
