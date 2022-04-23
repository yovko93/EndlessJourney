namespace EndlessJourney.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using EndlessJourney.Web.ViewModels.Trips;

    public class HomeViewModel
    {
        public IEnumerable<LatestTripViewModel> Trips { get; set; }
    }
}
