namespace EndlessJourney.Data.Models
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class Ship : BaseDeletableModel<int>
    {
        public Ship()
        {
            this.Trips = new HashSet<Trip>();
            this.Rooms = new HashSet<ShipRoom>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public int Crew { get; set; }

        public int Length { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public ICollection<ShipRoom> Rooms { get; set; }
    }
}
