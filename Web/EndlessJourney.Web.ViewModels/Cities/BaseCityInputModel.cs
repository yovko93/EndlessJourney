namespace EndlessJourney.Web.ViewModels.Cities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static EndlessJourney.Common.GlobalConstants.City;
    using static EndlessJourney.Common.GlobalConstants.Country;

    public abstract class BaseCityInputModel
    {
        [Required(ErrorMessage = EnterCityName)]
        [StringLength(MaximumNameLength, MinimumLength = MinimumNameLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = EnterCityDescription)]
        [StringLength(MaximumDescriptionLength, MinimumLength = MinimumDescriptionLength)]
        public string Description { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = EnterCityImage)]
        public string ImageUrl { get; set; }

        [Display(Name = CountryName)]
        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Countries { get; set; }
    }
}
