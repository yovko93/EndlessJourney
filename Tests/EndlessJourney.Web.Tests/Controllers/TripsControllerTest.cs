namespace EndlessJourney.Web.Tests.Controllers
{
    using EndlessJourney.Web.Controllers;
    using EndlessJourney.Web.ViewModels.Trips;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class TripsControllerTest
    {
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
