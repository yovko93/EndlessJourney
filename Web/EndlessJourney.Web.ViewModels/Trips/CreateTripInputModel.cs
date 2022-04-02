namespace EndlessJourney.Web.ViewModels.Trips
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CreateTripInputModel : BaseTripInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
