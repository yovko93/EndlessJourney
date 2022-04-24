namespace EndlessJourney.Web.Tests.Controllers
{
    using System.Linq;

    using EndlessJourney.Common;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Cities;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class CitiesControllerTest
    {
        [Fact]
        public void AllShouldReturnCorrectCities()
            => MyController<CitiesController>
                .Instance()
                .WithData(new City
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    State = "Test State",
                    ImageUrl = "Test ImageUrl",
                    Country = new Country
                    {
                        Id = 1,
                        Name = "Test Country",
                    },
                    IsDeleted = false,
                })
                .Calling(c => c.All())
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<CitiesListViewModel>()
                    .Passing(model =>
                    {
                        model.Count.ShouldBe(1);
                        model.Cities.FirstOrDefault(city => city.Name == "Test Name").ShouldNotBeNull();
                    }));

        [Fact]
        public void PostCreateShouldBeAllowedOnlyForPostRequestAndAuthorizedUsers()
            => MyController<CitiesController>
                .Instance()
                .Calling(c => c.Create(With.Default<CreateCityInputModel>()))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests()
                    .RestrictingForHttpMethod(HttpMethod.Post));

        [Fact]
        public void PostCreateShouldReturnViewWithTheSameModelWhenStateIsInvalid()
            => MyController<CitiesController>
                .Instance()
                .Calling(c => c.Create(With.Default<CreateCityInputModel>()))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<CreateCityInputModel>()
                    .Passing(city => city.Name.ShouldBeNull()));

        [Theory]
        [InlineData("Test Name", "Test Description", "Test State", "Test ImgUrl", 1)]
        public void PostCreateShouldReturnRedirectWithTempDataMessage(
            string name,
            string description,
            string state,
            string imageUrl,
            int countryId)
            => MyController<CitiesController>
                .Instance()
                .WithUser()
                .Calling(c => c.Create(new CreateCityInputModel
                {
                    Name = name,
                    Description = description,
                    State = state,
                    ImageUrl = imageUrl,
                    CountryId = countryId,
                }))
                .ShouldHave()
                .Data(data => data
                    .WithSet<City>(set =>
                    {
                        set.ShouldNotBeNull();
                        set.FirstOrDefault(city => city.Name == name).ShouldNotBeNull();
                    }))
                .AndAlso()
                .ShouldHave()
                .TempData(tempData => tempData
                    .ContainingEntryWithKey(GlobalConstants.Message))
                .AndAlso()
                .ShouldReturn()
                .Redirect(result => result
                    .To<CitiesController>(c => c.All()));
    }
}
