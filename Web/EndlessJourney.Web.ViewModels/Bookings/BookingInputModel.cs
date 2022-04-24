namespace EndlessJourney.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using static EndlessJourney.Common.GlobalConstants.Booking;

    public class BookingInputModel
    {
        [Required]
        [Range(MinimumAdults, MaximumAdults)]
        [Display(Name = AdultsOver18)]
        public int Adult { get; set; }

        [Display(Name = ChildrenBetween2And17Y)]
        public int Children { get; set; }

        [Display(Name = ChildrenBetween6And23M)]
        public int Infant { get; set; }

        public string TripId { get; set; }

        public string UserId { get; set; }
    }
}
