namespace EndlessJourney.Web.Tests.Controllers
{
    using System.Linq;

    using EndlessJourney.Common;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Bookings;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class BookingsControllerTest
    {
        [Fact]
        public void PostBookShouldBeAllowedOnlyForPostRequestAndAuthorizedUsers()
            => MyController<BookingsController>
                .Instance()
                .Calling(c => c.Book(With.Any<string>(), With.Default<BookingInputModel>()))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests()
                    .RestrictingForHttpMethod(HttpMethod.Post));

        [Fact]
        public void PostBookShouldReturnViewWithTheSameModelWhenStateIsInvalid()
            => MyController<BookingsController>
                .Instance()
                .Calling(c => c.Book(With.Any<string>(), With.Default<BookingInputModel>()))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(result => result
                    .WithModelOfType<BookingInputModel>()
                    .Passing(booking => booking.TripId.ShouldBeNull()));

        [Theory]
        [InlineData(1, 1)]
        public void PostBookShouldReturnRedirectWithTempDataMessage(
            int adult,
            int children)
            => MyController<BookingsController>
                .Instance()
                .WithUser()
                .Calling(c => c.Book("TestId", new BookingInputModel
                {
                    Adult = adult,
                    Children = children,
                }))
                .ShouldHave()
                .Data(data => data
                    .WithSet<Booking>(set =>
                    {
                        set.ShouldNotBeNull();
                        set.FirstOrDefault(booking => booking.Id == 1).ShouldNotBeNull();
                    }))
                .AndAlso()
                .ShouldHave()
                .TempData(tempData => tempData
                    .ContainingEntryWithKey(GlobalConstants.Message))
                .AndAlso()
                .ShouldReturn()
                .Redirect(result => result
                    .To<BookingsController>(c => c.Mine()));
    }
}
