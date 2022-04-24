namespace EndlessJourney.Web.Tests.Routes
{
    using EndlessJourney.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ShipsRouteTest
    {
        [Fact]
        public void GetAllWithPageShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Ships/All")
                .To<ShipsController>(c => c.All());

        [Fact]
        public void GetByIdShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Ships/ById/1")
                .To<ShipsController>(c => c.ById(1));
    }
}
