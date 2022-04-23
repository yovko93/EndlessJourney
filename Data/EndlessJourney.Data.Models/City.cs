namespace EndlessJourney.Data.Models
{
    using EndlessJourney.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string State { get; set; }

        public string ImageUrl { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
