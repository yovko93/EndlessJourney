namespace EndlessJourney.Web.ViewModels.Destinations
{
    using System.Collections.Generic;

    public class DestinationListViewModel : PagingViewModel
    {
        public IEnumerable<DestinationViewModel> Destinations { get; set; }
    }
}
