namespace EndlessJourney.Data.Models
{
    using System;

    using EndlessJourney.Data.Common.Models;

    public class ShipRoom : IDeletableEntity
    {
        public int ShipId { get; set; }

        public Ship Ship { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
