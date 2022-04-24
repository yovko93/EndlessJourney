namespace EndlessJourney.Web.ViewModels.Destinations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static EndlessJourney.Common.GlobalConstants.Destination;

    public class BaseDestinationInputModel
    {
        [Required(ErrorMessage = EnterDestinationName)]
        [StringLength(MaximumNameLength, MinimumLength = MinimumNameLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = EnterDestinationDescription)]
        [StringLength(MaximumDescriptionLength, MinimumLength = MinimumDescriptionLength)]
        public string Description { get; set; }

        [Display(Name = StartPoint)]
        public int StartPointId { get; set; }

        [Display(Name = EndPoint)]
        public int EndPointId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
    }
}
