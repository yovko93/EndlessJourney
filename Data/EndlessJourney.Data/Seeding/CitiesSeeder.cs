namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var citiesList = new List<City>()
            {
                new City
                {
                    Name = "Varna",
                    CountryId = 1,
                },
                new City
                {
                    Name = "Honolulu",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Los Angelis",
                    CountryId = 2,
                },
                new City
                {
                    Name = "San Francisco",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Miami",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Fort Lauderdale, FL",
                    CountryId = 2,
                },
                new City
                {
                    Name = "New York",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Southampton",
                    CountryId = 3,
                },
                new City
                {
                    Name = "Liverpool",
                    CountryId = 3,
                },
                new City
                {
                    Name = "Vancouver",
                    CountryId = 4,
                },
                new City
                {
                    Name = "Ensenada",
                    CountryId = 5,
                },
                new City
                {
                    Name = "Nassau",
                    CountryId = 6,
                },
                new City
                {
                    Name = "Barcelona",
                    CountryId = 7,
                },
                new City
                {
                    Name = "Lisbon",
                    CountryId = 8,
                },
                new City
                {
                    Name = "Le Havre",
                    CountryId = 9,
                },
                new City
                {
                    Name = "Hamburg",
                    CountryId = 10,
                },
                new City
                {
                    Name = "Hong Kong",
                    CountryId = 11,
                },
                new City
                {
                    Name = "Sydney",
                    CountryId = 12,
                },
                new City
                {
                    Name = "Dubai",
                    CountryId = 13,
                },
            };

            foreach (City city in citiesList)
            {
                var dbCity = await dbContext.Countries
                    .FirstOrDefaultAsync(x => x.Name == city.Name);

                if (dbCity == null)
                {
                    await dbContext.Cities.AddAsync(city);
                }
            }
        }
    }
}
