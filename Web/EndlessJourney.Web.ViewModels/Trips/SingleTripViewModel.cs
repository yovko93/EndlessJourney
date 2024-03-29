﻿namespace EndlessJourney.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class SingleTripViewModel : IMapFrom<Trip>, IHaveCustomMappings
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

        public string ShipImage { get; set; }

        public ICollection<Image> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Trip, SingleTripViewModel>()
                  .ForMember(x => x.ShipImage, opt =>
                      opt.MapFrom(x =>
                          x.Ship.Image.PathName));
        }
    }
}
