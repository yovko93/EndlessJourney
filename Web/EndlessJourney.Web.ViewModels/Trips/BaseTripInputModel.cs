namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseTripInputModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public int ShipId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Ships { get; set; }

        public int DestinationId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Destinations { get; set; }
    }
}
