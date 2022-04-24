namespace EndlessJourney.Web.Tests.Controllers
{
    using System.Linq;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Ships;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class ShipsControllerTest
    {
        [Fact]
        public void AllShouldReturnCorrectShips()
            => MyController<ShipsController>
                .Instance()
                .WithData(new Ship
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    Capacity = 1,
                    Crew = 1,
                    Length = 1,
                    Image = new Image(),
                })
                .Calling(c => c.All())
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<ShipsListViewModel>()
                    .Passing(model =>
                    {
                        model.Count.ShouldBe(1);
                        model.Ships.FirstOrDefault(ship => ship.Name == "Test Name").ShouldNotBeNull();
                    }));

        [Fact]
        public void ByIdShouldReturnNotFoundWhenInvalidShipId()
            => MyController<ShipsController>
                .Calling(c => c.ById(int.MaxValue))
                .ShouldReturn()
                .NotFound();

        [Fact]
        public void ByIdShouldReturnViewWithCorrectModelWhenAnonymousUser()
            => MyController<ShipsController>
                .Instance(instance => instance
                    .WithData(new Ship
                    {
                        Id = 1,
                        Name = "Test Name",
                        Description = "Test Description",
                        Capacity = 1,
                        Crew = 1,
                        Length = 1,
                        Image = new Image(),
                    }))
                .Calling(c => c.ById(1))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<SingleShipViewModel>()
                    .Passing(ship => ship.Id == 1));
    }
}
