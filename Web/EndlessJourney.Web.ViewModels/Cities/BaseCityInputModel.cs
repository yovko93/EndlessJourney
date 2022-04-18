namespace EndlessJourney.Web.ViewModels.Cities
{
    using System.Collections.Generic;

    public abstract class BaseCityInputModel
    {
        public string Name { get; set; }

        public string State { get; set; }

        public string ImageUrl { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Countries { get; set; }
    }
}
