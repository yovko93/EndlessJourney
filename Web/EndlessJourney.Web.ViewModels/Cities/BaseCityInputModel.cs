namespace EndlessJourney.Web.ViewModels.Cities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseCityInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string State { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Countries { get; set; }
    }
}
