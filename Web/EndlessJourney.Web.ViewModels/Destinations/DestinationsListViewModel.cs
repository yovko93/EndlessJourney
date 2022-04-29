namespace EndlessJourney.Web.ViewModels.Destinations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EndlessJourney.Data.Models;

    public class DestinationsListViewModel
    {
        public const int DestinationsPerPage = 4;

        public string EndPoint { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public DestinationSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalDestinations { get; set; }

        public IEnumerable<string> EndPoints { get; set; }

        public IEnumerable<DestinationViewModel> Destinations { get; set; }
    }
}
