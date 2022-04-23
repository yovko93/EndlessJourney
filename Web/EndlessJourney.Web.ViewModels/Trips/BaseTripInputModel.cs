namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public abstract class BaseTripInputModel : IMapFrom<Trip>
    {
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please enter a valid trip price.")]
        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public int ShipId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Ships { get; set; }

        public int DestinationId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Destinations { get; set; }
    }
}
