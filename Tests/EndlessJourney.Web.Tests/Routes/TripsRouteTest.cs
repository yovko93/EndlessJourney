namespace EndlessJourney.Web.Tests.Routes
{
    using EndlessJourney.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class TripsRouteTest
    {
        [Fact]
        public void GetAllShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Trips/All")
                .To<TripsController>(c => c.All(With.No<int>()));

        [Fact]
        public void GetAllWithPageShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Trips/All/1")
                .To<TripsController>(c => c.All(1));

        [Fact]
        public void GetByIdShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Trips/ById/1")
                .To<TripsController>(c => c.ById("1"));

        [Fact]
        public void GetCreateShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Trips/Create")
                .To<TripsController>(c => c.Create());

        [Fact]
        public void GetEditShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("/Trips/Edit/test")
                .To<TripsController>(c => c.Edit("test"));
    }
}
