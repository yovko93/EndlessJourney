namespace EndlessJourney.Web.ViewModels.Trips
{
    using System.ComponentModel.DataAnnotations;

    public class EditTripInputModel : BaseTripInputModel
    {
        [Required]
        public string Id { get; set; }
    }
}
