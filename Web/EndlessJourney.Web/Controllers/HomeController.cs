namespace EndlessJourney.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels;
    using EndlessJourney.Web.ViewModels.Home;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ITripsService tripsService;

        public HomeController(
            ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public async Task<IActionResult> Index()
        {
            var randomTrips = await this.tripsService.GetRandomAsync<TripViewModel>(3);

            var viewModel = new HomeViewModel
            {
                Trips = randomTrips,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
