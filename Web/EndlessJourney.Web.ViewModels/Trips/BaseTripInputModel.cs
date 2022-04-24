namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    using static EndlessJourney.Common.GlobalConstants.Destination;
    using static EndlessJourney.Common.GlobalConstants.Ship;
    using static EndlessJourney.Common.GlobalConstants.Trip;

    public abstract class BaseTripInputModel : IMapFrom<Trip>
    {
        [Display(Name = StartDateInput)]
        public DateTime StartDate { get; set; }

        [Display(Name = EndDateInput)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = EnterValidPrice)]
        public decimal Price { get; set; }

        public int? Discount { get; set; }

        [Display(Name = ShipName)]
        [Required(ErrorMessage = ShipCannotBeNull)]
        public int ShipId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Ships { get; set; }

        [Required(ErrorMessage = DestinationCannotBeNull)]
        public int DestinationId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Destinations { get; set; }
    }
}
