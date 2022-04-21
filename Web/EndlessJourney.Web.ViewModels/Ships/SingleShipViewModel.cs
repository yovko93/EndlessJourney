namespace EndlessJourney.Web.ViewModels.Ships
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class SingleShipViewModel : IMapFrom<Ship>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public int Crew { get; set; }

        public int Length { get; set; }

        public string ImagePathName { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
