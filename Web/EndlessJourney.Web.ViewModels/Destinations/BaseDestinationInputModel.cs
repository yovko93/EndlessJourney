namespace EndlessJourney.Web.ViewModels.Destinations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BaseDestinationInputModel
    {
        [Required(ErrorMessage = "Please enter destination description.")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter destination description.")]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }

        [Display(Name = "Start Point")]
        public int StartPointId { get; set; }

        [Display(Name = "End Point")]
        public int EndPointId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
    }
}
