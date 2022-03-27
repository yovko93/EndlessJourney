namespace EndlessJourney.Data.Models
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class Benefit : BaseDeletableModel<int>
    {
        public Benefit()
        {
            this.Rooms = new HashSet<RoomBenefit>();
        }

        public string Name { get; set; }

        public ICollection<RoomBenefit> Rooms { get; set; }
    }
}
