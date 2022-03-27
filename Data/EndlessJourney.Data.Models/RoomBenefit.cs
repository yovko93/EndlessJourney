namespace EndlessJourney.Data.Models
{
    using System;

    using EndlessJourney.Data.Common.Models;

    public class RoomBenefit : IDeletableEntity
    {
        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int BenefitId { get; set; }

        public Benefit Benefit { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
