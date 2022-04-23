namespace EndlessJourney.Web.ViewModels.Destinations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BaseDestinationInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Start Point")]
        public int StartPointId { get; set; }

        [Display(Name = "End Point")]
        public int EndPointId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
    }
}
