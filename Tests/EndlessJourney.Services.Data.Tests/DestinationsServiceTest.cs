namespace EndlessJourney.Services.Data.Tests
{
    using System.Threading.Tasks;

    using EndlessJourney.Data;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Data.Repositories;
    using EndlessJourney.Services.Data.Destinations;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class DestinationsServiceTest
    {
        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DestinationsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Destinations.Add(new Destination());
            dbContext.Destinations.Add(new Destination());
            dbContext.Destinations.Add(new Destination());
            await dbContext.SaveChangesAsync();
            using var repository = new EfDeletableEntityRepository<Destination>(dbContext);
            var service = new DestinationsService(repository);
            Assert.Equal(3, service.GetCountAsync().Result);
        }
    }
}
