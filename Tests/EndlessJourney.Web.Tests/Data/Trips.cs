namespace EndlessJourney.Web.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using EndlessJourney.Data.Models;

    public static class Trips
    {
        public static IEnumerable<Trip> ThreeTrips
            => Enumerable.Range(0, 10).Select(t => new Trip
            {
            });
    }
}
