namespace EndlessJourney.Web.ViewModels.Cities
{
    using System.Collections.Generic;

    public class CitiesListViewModel
    {
        public IEnumerable<CityViewModel> Cities { get; set; }

        public int Count { get; set; }
    }
}
