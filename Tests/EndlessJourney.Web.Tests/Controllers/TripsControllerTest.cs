namespace EndlessJourney.Web.Tests.Controllers
{
    using System;
    using System.Linq;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Trips;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class TripsControllerTest
    {
        [Fact]
        public void AllShouldReturnCorrectTrips()
            => MyController<TripsController>
                .Instance()
                .WithData(new Trip
                {
                    Id = "Test Pass",
                    StartDate = new DateTime(2022, 01, 01),
                    EndDate = new DateTime(2022, 02, 02),
                    Price = 200,
                    Discount = 5,
                    Destination = new Destination
                    {
                        Id = 1,
                        Name = "Test",
                        Description = "Test Desc",
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
                    },
                    Ship = new Ship
                    {
                        Id = 1,
                        Name = "Test",
                        Crew = 1,
                        Length = 1,
                        Capacity = 1,
                    },
                })
                .Calling(c => c.All(1))
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<TripsListViewModel>()
                    .Passing(model =>
                    {
                        model.PageNumber.ShouldBe(1);
                        model.ItemsPerPage.ShouldBe(6);
                        model.Count.ShouldBe(1);
                        model.Trips.FirstOrDefault(trip => trip.DestinationName == "Test").ShouldNotBeNull();
                    }));

        [Fact]
        public void PostCreateShouldBeAllowedOnlyForPostRequestAndAuthorizedUsers()
            => MyController<TripsController>
                .Instance()
                .Calling(c => c.Create(With.Default<CreateTripInputModel>()))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests()
                    .RestrictingForHttpMethod(HttpMethod.Post));

        [Fact]
        public void PostCreateShouldReturnViewWithTheSameModelWhenStateIsInvalid()
            => MyController<TripsController>
                .Instance()
                .Calling(c => c.Create(With.Default<CreateTripInputModel>()))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<CreateTripInputModel>()
                    .Passing(trip => trip.Images.ShouldBeNull()));

        [Fact]
        public void DeleteShouldReturnNotFoundWhenInvalidId()
            => MyController<TripsController>
                .Calling(c => c.Delete(With.Any<string>()))
                .ShouldReturn()
                .NotFound();

        [Fact]
        public void DeleteShouldHaveRestrictionsForAuthorizedUsers()
            => MyController<TripsController>
                .Calling(c => c.Delete(With.Any<string>()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForAuthorizedRequests());
    }
}
