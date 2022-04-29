namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Bookings;
    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels.Bookings;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants;
    using static EndlessJourney.Common.GlobalConstants.Booking;

    public class BookingsController : Controller
    {
        private readonly IBookingsService bookingsService;
        private readonly ITripsService tripsService;

        public BookingsController(
            IBookingsService bookingsService,
            ITripsService tripsService)
        {
            this.bookingsService = bookingsService;
            this.tripsService = tripsService;
        }

        [Authorize]
        public async Task<IActionResult> Mine()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = new BookingsListViewModel
            {
                Bookings = await this.bookingsService.GetAllByUserIdAsync<BookingViewModel>(userId),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Book(string id)
        {
            var viewModel = new BookingInputModel();
            viewModel.TripId = id;
            viewModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Book(string id, BookingInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            inputModel.TripId = id;
            inputModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.bookingsService.BookAsync(inputModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                this.TempData[Message] = ex.Message;

                return this.RedirectToAction(nameof(TripsController.All), "Trips");
            }

            this.TempData[Message] = TripBookedSuccessfully;

            return this.RedirectToAction(nameof(this.Mine));
        }

        public async Task<decimal> TotalSum(string id)
        {
            var tripPrice = await this.tripsService.GetTripPriceAsync(id);

            return tripPrice;
        }
    }
}
