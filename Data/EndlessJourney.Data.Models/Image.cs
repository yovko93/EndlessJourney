namespace EndlessJourney.Data.Models
{
    using EndlessJourney.Data.Common.Models;

    public class Image : BaseDeletableModel<int>
    {
        public string TripId { get; set; }

        public int? ShipId { get; set; }

        public string PathName { get; set; }

        public string ImageUrl { get; set; }

        public string Extension { get; set; }
    }
}
