namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class SingleTripViewModel : IMapFrom<Trip>
    {
        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public string DestinationName { get; set; }

        public string DestinationStartPointName { get; set; }

        public string DestinationEndPointName { get; set; }

        public string ShipName { get; set; }

        public string ShipDescription { get; set; }

        public int ShipCrew { get; set; }

        public int ShipCapacity { get; set; }

        public int ShipLength { get; set; }

        public string ShipImagePathName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Image> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Trip, SingleTripViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().ImageUrl != null ?
                        x.Images.FirstOrDefault().ImageUrl :
                        "/images/trips/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
                    .ForMember(x => x.ShipImagePathName, opt =>
                    opt.MapFrom(x =>
                        x.Ship.Image.ImageUrl != null ?
                        x.Ship.Image.ImageUrl :
                        "/images/" + x.Ship.Image.PathName + "." + x.Ship.Image.Extension));
        }

        // TODO show all images
    }
}
