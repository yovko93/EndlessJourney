namespace EndlessJourney.Web.ViewModels.Cities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseCityInputModel
    {
        [Required(ErrorMessage = "Please enter city name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter city description.")]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = "Please enter imageUrl.")]
        public string ImageUrl { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Countries { get; set; }
    }
}
