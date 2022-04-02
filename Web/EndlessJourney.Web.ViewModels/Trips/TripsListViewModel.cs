namespace EndlessJourney.Web.ViewModels.Trips
{
    using System.Collections.Generic;

    public class TripsListViewModel : PagingViewModel
    {
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}
