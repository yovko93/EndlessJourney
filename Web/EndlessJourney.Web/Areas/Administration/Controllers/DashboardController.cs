namespace EndlessJourney.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels.Administration.Dashboard;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class DashboardController : AdministrationController
    {
        private readonly ITripsService tripsService;

        public DashboardController(
            ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public async Task<IActionResult> Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            var allTrips = await this.tripsService
                .GetRandomAsync<TripViewModel>(10);

            foreach (var trip in allTrips)
            {
                dataPoints.Add(new DataPoint(trip.DestinationName, (double)trip.Price));
            }

            this.ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return this.View();
        }
    }
}
