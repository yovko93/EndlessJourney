namespace EndlessJourney.Web.ViewModels.Trips
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class EditTripInputModel : BaseTripInputModel, IMapFrom<Trip>
    {
        public string Id { get; set; }
    }
}
