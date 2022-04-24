namespace EndlessJourney.Web.Tests.Routes
{
    using EndlessJourney.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class BookingsRouteTest
    {
        [Fact]
        public void GetMineWithPageShouldBeRoutedCorrectly()
           => MyRouting
               .Configuration()
               .ShouldMap("/Bookings/Mine")
               .To<BookingsController>(c => c.Mine());

        [Fact]
        public void GetBookShouldBeRoutedCorrectly()
           => MyRouting
               .Configuration()
               .ShouldMap("/Bookings/Book/1")
               .To<BookingsController>(c => c.Book("1"));
    }
}
