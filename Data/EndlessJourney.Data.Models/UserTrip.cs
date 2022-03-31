namespace EndlessJourney.Data.Models
{
    using System;

    using EndlessJourney.Data.Common.Models;

    public class UserTrip : IDeletableEntity
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string TripId { get; set; }

        public Trip Trip { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
