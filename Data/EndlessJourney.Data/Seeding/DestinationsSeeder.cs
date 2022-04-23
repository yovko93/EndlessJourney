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
                    StartPointId = 19,
                    EndPointId = 17,
                },
                new Destination
                {
                    Name = "Western Mediterranean",
                    Description = "The enchanting old town of Dalt Vila in Ibiza and Rome’s historic centre (from Civitavecchia) are two of the standout sights to savour on this voyage, sailing from Southampton.",
                    StartPointId = 17,
                    EndPointId = 3,
                },
                new Destination
                {
                    Name = "Eastbound Transatlantic Crossing",
                    Description = "Witness New York’s skyscrapers fade into the horizon and savour exquisite fine dining, music and theatre each day, as you embark on this iconic Transatlantic Crossing to Southampton.",
                    StartPointId = 18,
                    EndPointId = 17,
                },
                new Destination
                {
                    Name = "Roundtrip Transatlantic",
                    Description = "Pack as much as you please for this Transatlantic Crossing. Enjoy the convenience of sailing roundtrip from New York and the chance to explore Southampton – a favourite city of Jane Austen.",
                    StartPointId = 18,
                    EndPointId = 18,
                },
                new Destination
                {
                    Name = "Transatlantic Crossing, Panama Canal",
                    Description = "Balancing sun-filled shores with cosmopolitan cities, this voyage offers relaxation and exploration in equal measure, with calls ashore in Aruba, Costa Rica, Mexico and Grand Turk.",
                    StartPointId = 8,
                    EndPointId = 12,
                },
                new Destination
                {
                    Name = "Hamburg Short Break",
                    Description = "Savour a relaxing sea days on the boat, and be treated to special Royal Shakespeare Company performances on board, before disembarking to explore Hamburg’s canals, museums, and old town.",
                    StartPointId = 17,
                    EndPointId = 7,
                },
                new Destination
                {
                    Name = "Dubai To Sydney",
                    Description = "Thailand’s palm-fringed beaches, Malaysia’s fiery curries and the historic city of Hue (from Chan May) await discovery on this voyage which offers overnight calls in Hong Kong and Singapore.",
                    StartPointId = 4,
                    EndPointId = 5,
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
