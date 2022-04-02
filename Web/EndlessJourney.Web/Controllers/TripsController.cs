namespace EndlessJourney.Web.Controllers
{
    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            var viewModel = new TripsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                TripsCount = this.tripsService.GetCount(),
                Trips = await this.tripsService.GetAllAsync<TripViewModel>(),
            };

            return this.View(viewModel);
        }


    }
}
