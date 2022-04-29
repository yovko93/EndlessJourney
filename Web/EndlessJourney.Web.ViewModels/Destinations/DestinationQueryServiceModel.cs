namespace EndlessJourney.Web.ViewModels.Destinations
{
    using System.Collections.Generic;

    public class DestinationQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int DestinationsPerPage { get; set; }

        public int TotalDestinations { get; set; }

        public IEnumerable<DestinationViewModel> Destinations { get; set; }
    }
}
