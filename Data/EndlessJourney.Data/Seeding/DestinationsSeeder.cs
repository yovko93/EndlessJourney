namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class DestinationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var destiantionsList = new List<Destination>()
            {
                new Destination
                {
                    Name = "Eastbound Transatlantic Crossing from Fort Lauderdale",
                    Description = "Savour a day in port to explore New York's iconic landmarks before embarking on an eastbound Transatlantic Crossing to Southampton on this ocean voyage departing from Fort Lauderdale.",
                    StartPointId = 6,
                    EndPointId = 8,
                },
                new Destination
                {
                    Name = "Western Mediterranean",
                    StartPointId = 8,
                    EndPointId = 13,
                },
                new Destination
                {
                    Name = "Eastbound Transatlantic Crossing",
                    StartPointId = 7,
                    EndPointId = 8,
                },
                new Destination
                {
                    Name = "Roundtrip Transatlantic",
                    StartPointId = 7,
                    EndPointId = 7,
                },
                new Destination
                {
                    Name = "Transatlantic Crossing, Panama Canal",
                    Description = "Balancing sun-filled shores with cosmopolitan cities, this voyage offers relaxation and exploration in equal measure, with calls ashore in Aruba, Costa Rica, Mexico and Grand Turk.",
                    StartPointId = 8,
                    EndPointId = 10,
                },
                new Destination
                {
                    Name = "Hamburg Short Break",
                    StartPointId = 16,
                    EndPointId = 14,
                },
                new Destination
                {
                    Name = "Dubai To Sydney",
                    StartPointId = 19,
                    EndPointId = 18,
                },
            };

            foreach (Destination destination in destiantionsList)
            {
                var dbDestination = await dbContext.Destinations
                    .FirstOrDefaultAsync(x =>
                        x.StartPointId == destination.StartPointId
                            && x.EndPointId == destination.EndPointId
                            && x.Name == destination.Name);

                if (dbDestination == null)
                {
                    await dbContext.Destinations.AddAsync(destination);
                }
            }
        }
    }
}
