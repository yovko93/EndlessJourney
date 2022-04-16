namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseTripInputModel
    {
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public int ShipId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Ships { get; set; }

        public int DestinationId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Destinations { get; set; }
    }
}
