namespace EndlessJourney.Web.Tests.Routes
{
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Cities;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CitiesRouteTest
    {
        [Fact]
        public void GetAllWithPageShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Cities/All")
                .To<CitiesController>(c => c.All());

        [Fact]
        public void GetCreateShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Cities/Create")
                .To<CitiesController>(c => c.Create());

        [Theory]
        [InlineData("Name", "Description", "State", "ImageUrl")]
        public void PostCreateShouldBeRoutedCorrectly(string name, string description, string state, string imageUrl)
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Post)
                    .WithLocation("/Cities/Create")
                    .WithFormFields(new
                    {
                        Name = name,
                        Description = description,
                        State = state,
                        ImageUrl = imageUrl,
                    }))
                .To<CitiesController>(c => c.Create(new CreateCityInputModel
                {
                    Name = name,
                    Description = description,
                    State = state,
                    ImageUrl = imageUrl,
                }))
                .AndAlso()
                .ToValidModelState();
    }
}
