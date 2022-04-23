namespace EndlessJourney.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "EndlessJourney";

        public class RolesNamesConstants
        {
            public const string AdministratorRoleName = "Administrator";
        }

        public class Cache
        {
            public const string LatestTripsCacheKey = nameof(LatestTripsCacheKey);
        }

        public class Trip
        {
            public const string TripAdded = "Trip added successfully!";
            public const string TripNotFound = "Trip not found!";
        }

        public class Booking
        {
            public const string TripBookedSuccessfully = "The trip is booked successfully!";
            public const string AlreadyBooked = "Trip is booked already!";
        }

        public class Destination
        {
            public const string DestinationAdded = "Destination added successfully!";
            public const string DestinationAlreadyExist = "Destination already exist!";
        }

        public class City
        {
            public const string CityAdded = "City added successfully!";
            public const string CityAlreadyExist = "City already exist!";
        }
    }
}
