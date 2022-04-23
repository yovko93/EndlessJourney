namespace EndlessJourney.Web.ViewModels.Bookings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;

    public class BookingViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PathName { get; set; }

        public string ShipName { get; set; }

        public string DestinationName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Trip, BookingViewModel>()
                 .ForMember(x => x.DestinationName, opt =>
                     opt.MapFrom(x =>
                         x.Destination.StartPoint.Name + " to " + x.Destination.EndPoint.Name))
                 .ForMember(x => x.PathName, opt =>
                         opt.MapFrom(x =>
                             x.Images.FirstOrDefault().PathName));
        }
    }
}
