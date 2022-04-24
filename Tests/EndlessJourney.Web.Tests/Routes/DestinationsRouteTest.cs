namespace EndlessJourney.Web.Tests.Routes
{
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Destinations;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class DestinationsRouteTest
    {
        [Fact]
        public void GetAllWithPageShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Destinations/All")
                .To<DestinationsController>(c => c.All());

        [Fact]
        public void GetCreateShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Destinations/Create")
                .To<DestinationsController>(c => c.Create());

        [Theory]
        [InlineData("Name", "Description")]
        public void PostCreateShouldBeRoutedCorrectly(string name, string description)
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Post)
                    .WithLocation("/Destinations/Create")
                    .WithFormFields(new
                    {
                        Name = name,
                        Description = description,
                    }))
                .To<DestinationsController>(c => c.Create(new CreateDestinationInputModel
                {
                    Name = name,
                    Description = description,
                }))
                .AndAlso()
                .ToValidModelState();
    }
}
