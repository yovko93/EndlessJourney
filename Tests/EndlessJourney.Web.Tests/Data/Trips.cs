namespace EndlessJourney.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EndlessJourney.Data.Models;

    public static class Trips
    {
        public static List<Trip> GetTrips(int count)
        {
            var trips = Enumerable
                .Range(1, count)
                .Select(i => new Trip
                {
                    Id = "Test Pass",
                    StartDate = new DateTime(2022, 01, 01),
                    EndDate = new DateTime(2022, 02, 02),
                    Price = 200,
                    Discount = 5,
                    Destination = new Destination
                    {
                        Id = 1,
                        Name = "Test",
                        Description = "Test Desc",
                        StartPoint = new City
                        {
                            Name = "Test Name",
                            Description = "Test Description",
                            State = "Test State",
                            ImageUrl = "Test ImageUrl",
                        },
                        EndPoint = new City
                        {
                            Name = "Test Name",
                            Description = "Test Description",
                            State = "Test State",
                            ImageUrl = "Test ImageUrl",
                        },
                    },
                    Ship = new Ship
                    {
                        Id = 1,
                        Name = "Test",
                        Crew = 1,
                        Length = 1,
                        Capacity = 1,
                    },
                })
                .ToList();

            return trips;
        }
    }
}
