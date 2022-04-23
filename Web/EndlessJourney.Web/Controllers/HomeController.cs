namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels;
    using EndlessJourney.Web.ViewModels.Home;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using static EndlessJourney.Common.GlobalConstants.Cache;

    public class HomeController : BaseController
    {
        private readonly ITripsService tripsService;
        private readonly IMemoryCache cache;

        public HomeController(
            ITripsService tripsService,
            IMemoryCache cache)
        {
            this.tripsService = tripsService;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var latestTrips = this.cache.Get<List<LatestTripViewModel>>(LatestTripsCacheKey);

            if (latestTrips == null)
            {
                latestTrips = this.tripsService
                   .Latest<LatestTripViewModel>()
                   .ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(LatestTripsCacheKey, latestTrips, cacheOptions);
            }

            var viewModel = new HomeViewModel
            {
                Trips = latestTrips,
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
