namespace EndlessJourney.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data;
    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Data.Repositories;
    using EndlessJourney.Services.Data.Cities;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class CitiesServiceTest
    {
        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CitiesTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Cities.Add(new City());
            dbContext.Cities.Add(new City());
            dbContext.Cities.Add(new City());
            await dbContext.SaveChangesAsync();
            using var repository = new EfDeletableEntityRepository<City>(dbContext);
            var service = new CitiesService(repository);
            Assert.Equal(3, service.GetCountAsync().Result);
        }
    }
}
