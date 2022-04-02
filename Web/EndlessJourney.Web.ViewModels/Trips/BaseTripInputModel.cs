namespace EndlessJourney.Web.ViewModels.Trips
{
    public abstract class BaseTripInputModel
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public int DestinationId { get; set; }

        public int ShipId { get; set; }
    }
}
