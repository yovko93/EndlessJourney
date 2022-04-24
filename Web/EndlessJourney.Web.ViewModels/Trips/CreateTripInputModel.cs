namespace EndlessJourney.Web.ViewModels.Trips
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static EndlessJourney.Common.GlobalConstants.Trip;

    public class CreateTripInputModel : BaseTripInputModel
    {
        [Required(ErrorMessage = ShouldUploadImage)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
