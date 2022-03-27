namespace EndlessJourney.Data.Models
{
    using System;
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class Trip : BaseDeletableModel<string>
    {
        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Bookings = new HashSet<Booking>();
            this.Images = new HashSet<Image>();
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        public int ShipId { get; set; }

        public Ship Ship { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
