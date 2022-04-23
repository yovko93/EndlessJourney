namespace EndlessJourney.Web.ViewModels.Cities
{
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string State { get; set; }

        public string ImageUrl { get; set; }

        public string CountryName { get; set; }
    }
}
