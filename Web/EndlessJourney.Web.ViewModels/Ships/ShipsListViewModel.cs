namespace EndlessJourney.Web.ViewModels.Ships
{
    using System.Collections.Generic;

    public class ShipsListViewModel
    {
        public IEnumerable<ShipViewModel> Ships { get; set; }

        public int Count { get; set; }
    }
}
