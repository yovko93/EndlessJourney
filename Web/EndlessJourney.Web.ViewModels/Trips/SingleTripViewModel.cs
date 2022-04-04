namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Linq;

    using AutoMapper;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class SingleTripViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AvailableSeats { get; set; }

        public string DestinationName { get; set; }

        public string DestinationStartPointName { get; set; }

        public string DestinationEndPointName { get; set; }

        public string ShipName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Trip, SingleTripViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().ImageUrl != null ?
                        x.Images.FirstOrDefault().ImageUrl :
                        "/images/trips/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
                .ForMember(x => x.AvailableSeats, opt =>
                    opt.MapFrom(x => x.Ship.Capacity));
        }

        // TODO show all images
    }
}
