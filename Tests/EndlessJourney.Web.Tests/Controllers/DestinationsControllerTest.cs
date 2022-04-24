namespace EndlessJourney.Web.Tests.Controllers
{
    using System.Linq;

    using EndlessJourney.Common;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Destinations;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class DestinationsControllerTest
    {
        [Fact]
        public void AllShouldReturnCorrectDestinations()
            => MyController<DestinationsController>
                .Instance()
                .WithData(new Destination
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    StartPoint = new City
                    {
                        Name = "Test Name",
                        Description = "Test Description",
                        State = "Test State",
                        ImageUrl = "Test ImageUrl",
                    },
                    EndPoint = new City
                    {
                        Name = "Test Name",
                        Description = "Test Description",
                        State = "Test State",
                        ImageUrl = "Test ImageUrl",
                    },
                })
                .Calling(c => c.All())
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<DestinationsListViewModel>()
                    .Passing(model =>
                    {
                        model.Destinations.Count().ShouldBe(1);
                        model.Destinations.FirstOrDefault(destination => destination.Name == "Test Name").ShouldNotBeNull();
                    }));

        [Fact]
        public void PostCreateShouldBeAllowedOnlyForPostRequestAndAuthorizedUsers()
            => MyController<DestinationsController>
                .Instance()
                .Calling(c => c.Create(With.Default<CreateDestinationInputModel>()))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests()
                    .RestrictingForHttpMethod(HttpMethod.Post));

        [Fact]
        public void PostCreateShouldReturnViewWithTheSameModelWhenStateIsInvalid()
            => MyController<DestinationsController>
                .Instance()
                .Calling(c => c.Create(With.Default<CreateDestinationInputModel>()))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<CreateDestinationInputModel>()
                    .Passing(destination => destination.Name.ShouldBeNull()));

        [Theory]
        [InlineData("Test Name", "Test Description", 1, 2)]
        public void PostCreateShouldReturnRedirectWithTempDataMessage(
            string name,
            string description,
            int startPointId,
            int endPointId)
            => MyController<DestinationsController>
                .Instance()
                .WithUser()
                .Calling(c => c.Create(new CreateDestinationInputModel
                {
                    Name = name,
                    Description = description,
                    StartPointId = startPointId,
                    EndPointId = endPointId,
                }))
                .ShouldHave()
                .Data(data => data
                    .WithSet<Destination>(set =>
                    {
                        set.ShouldNotBeNull();
                        set.FirstOrDefault(destination => destination.Name == name).ShouldNotBeNull();
                    }))
                .AndAlso()
                .ShouldHave()
                .TempData(tempData => tempData
                    .ContainingEntryWithKey(GlobalConstants.Message))
                .AndAlso()
                .ShouldReturn()
                .Redirect(result => result
                    .To<DestinationsController>(c => c.All()));
    }
}
