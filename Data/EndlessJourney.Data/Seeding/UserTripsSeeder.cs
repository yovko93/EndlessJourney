namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserTripsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userTripsList = new List<UserTrip>()
            {
                new UserTrip
                {
                    UserId = " ",
                    TripId = " ",
                },
            };

            foreach (UserTrip userTrip in userTripsList)
            {
                var dbUserTrip = await dbContext.UserTrips
                    .FirstOrDefaultAsync(x =>
                        x.UserId == userTrip.UserId
                        && x.TripId == userTrip.TripId);

                if (dbUserTrip == null)
                {
                    await dbContext.UserTrips.AddAsync(userTrip);
                }
            }
        }
    }
}
