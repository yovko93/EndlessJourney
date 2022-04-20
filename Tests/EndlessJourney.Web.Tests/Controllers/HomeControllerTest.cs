namespace EndlessJourney.Web.Tests.Controllers
{
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Home;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static EndlessJourney.Web.Tests.Trips;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
            => MyController<HomeController>
                .Instance(controller => controller
                    .WithData(ThreeTrips))
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
