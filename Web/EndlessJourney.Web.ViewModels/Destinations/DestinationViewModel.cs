namespace EndlessJourney.Web.ViewModels.Destinations
{
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class DestinationViewModel : IMapFrom<Destination>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StartPointName { get; set; }

        public string EndPointName { get; set; }

        public string EndPointImageUrl { get; set; }
    }
}
