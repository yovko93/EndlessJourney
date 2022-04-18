namespace EndlessJourney.Data.Models
{
    using EndlessJourney.Data.Common.Models;

    public class Booking : BaseDeletableModel<int>
    {
        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public string Details { get; set; }

        public int Adult { get; set; }

        public int Children { get; set; }

        public int Infant { get; set; }

        public string TripId { get; set; }

        public Trip Trip { get; set; }

        // public string PaymentId { get; set; }
    }
}
