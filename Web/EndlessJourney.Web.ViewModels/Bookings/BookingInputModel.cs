namespace EndlessJourney.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    public class BookingInputModel
    {
        [Required]
        [Range(1, 4)]
        [Display(Name = "Adults (18+)")]
        public int Adult { get; set; }

        [Display(Name = "Children (2-17 years)")]
        public int Children { get; set; }

        [Display(Name = "Infants (6-23 months)")]
        public int Infant { get; set; }

        public string TripId { get; set; }

        public string UserId { get; set; }
    }
}
