namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Linq;

    using AutoMapper;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class TripViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PathName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public string DestinationName { get; set; }

        public string DestinationStartPointName { get; set; }

        public string DestinationEndPointName { get; set; }

        public string ShipName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Trip, TripViewModel>()
                 .ForMember(x => x.PathName, opt =>
                     opt.MapFrom(x =>
                         x.Images.FirstOrDefault().PathName));
        }
    }
}
