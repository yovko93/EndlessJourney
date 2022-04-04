namespace EndlessJourney.Data.Models
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class Room : BaseDeletableModel<int>
    {
        public Room()
        {
            this.Benefits = new HashSet<RoomBenefit>();
            this.Ships = new HashSet<ShipRoom>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Stars { get; set; }

        public ICollection<ShipRoom> Ships { get; set; }

        public ICollection<RoomBenefit> Benefits { get; set; }
    }
}
