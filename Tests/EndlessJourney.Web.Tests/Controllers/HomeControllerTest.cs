namespace EndlessJourney.Web.Tests.Controllers
{
    using System;
    using System.Linq;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Home;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void AllShouldReturnCorrectTrips()
            => MyController<HomeController>
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
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<HomeViewModel>()
                    .Passing(model =>
                    {
                        model.Trips.Count().ShouldBe(1);
                        model.Trips.FirstOrDefault(trip => trip.DestinationName == "Test").ShouldNotBeNull();
                    }));

        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
            => MyController<HomeController>
                .Instance(controller => controller
                    .WithData(Trips.GetTrips(1)))
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<HomeViewModel>()
                    .Passing(model => model.Should().NotBeNull()));

        [Fact]
        public void ErrorShouldReturnView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Error())
                .ShouldReturn()
                .View();
    }
}
