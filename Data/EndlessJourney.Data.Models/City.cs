namespace EndlessJourney.Data.Models
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            // this.Trips = new HashSet<Trip>();
            // this.Destinations = new HashSet<Destination>();
        }

        public string Name { get; set; }

        // public string State { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }

        // public ICollection<Trip> Trips { get; set; }
        // public ICollection<Destination> Destinations { get; set; }
    }
}
