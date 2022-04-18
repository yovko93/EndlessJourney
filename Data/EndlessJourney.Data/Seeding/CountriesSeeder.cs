namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var countriesList = new List<Country>()
            {
                new Country
                {
                    Name = "Bulgaria",
                    Capital = "Sofia",
                },
                new Country
                {
                    Name = "USA",
                    Capital = "Washington, D.C.",
                },
                new Country
                {
                    Name = "England",
                    Capital = "London",
                },
                new Country
                {
                    Name = "Canada",
                    Capital = "Ottawa",
                },
                new Country
                {
                    Name = "Mexico",
                    Capital = "Mexico City",
                },
                new Country
                {
                    Name = "Bahamas",
                    Capital = "Nassau",
                },
                new Country
                {
                    Name = "Spain",
                    Capital = "Madrid",
                },
                new Country
                {
                    Name = "Portugal",
                    Capital = "Lisbon",
                },
                new Country
                {
                    Name = "France",
                    Capital = "Paris",
                },
                new Country
                {
                    Name = "Germany",
                    Capital = "Berlin",
                },
                new Country
                {
                    Name = "China",
                    Capital = "Beijing",
                },
                new Country
                {
                    Name = "Australia",
                    Capital = "Canberra",
                },
                new Country
                {
                    Name = "United Arab Emirates",
                    Capital = "Abu Dhabi",
                },
                new Country
                {
                    Name = "Italy",
                    Capital = "Rome",
                },
                new Country
                {
                    Name = "Brazil",
                    Capital = "Brazil",
                },
                new Country
                {
                    Name = "Chile",
                    Capital = "Santiago",
                },
                new Country
                {
                    Name = "Argentina",
                    Capital = "Buenos Aires",
                },
            };

            foreach (Country country in countriesList)
            {
                var dbCountry = await dbContext.Countries
                    .FirstOrDefaultAsync(x => x.Name == country.Name);

                if (dbCountry == null)
                {
                    await dbContext.Countries.AddAsync(country);
                }
            }
        }
    }
}
