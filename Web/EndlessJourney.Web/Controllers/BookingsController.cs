namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Bookings;
    using EndlessJourney.Web.ViewModels.Bookings;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BookingsController : Controller
    {
        private readonly IBookingsService bookingsService;

        public BookingsController(
            IBookingsService bookingsService)
        {
            this.bookingsService = bookingsService;
        }

        [Authorize]
        public async Task<IActionResult> Mine(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = new TripsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = await this.bookingsService.GetCountByUserIdAsync(userId),
                Trips = await this.bookingsService.GetAllByUserIdAsync<TripViewModel>(userId, id, ItemsPerPage),
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

                return this.View(inputModel);
            }

            this.TempData["Message"] = "Trip booked successfully!";

            return this.RedirectToAction(nameof(this.Mine));
        }
    }
}
