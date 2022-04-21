namespace EndlessJourney.Web.ViewModels.Ships
{
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class ShipViewModel : IMapFrom<Ship>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePathName { get; set; }
    }
}
