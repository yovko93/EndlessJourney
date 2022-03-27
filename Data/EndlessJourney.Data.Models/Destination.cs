namespace EndlessJourney.Data.Models
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class Destination : BaseDeletableModel<int>
    {
        public Destination()
        {
            this.Trips = new HashSet<Trip>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
