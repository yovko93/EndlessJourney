namespace EndlessJourney.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "EndlessJourney";
        public const string Message = "Message";

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
            public const string TripExistAlready = "This Trip exist already!";
            public const string EnterValidPrice = "Please enter a valid trip price!";
            public const string EndDateInput = "End date";
            public const string StartDateInput = "Start date";
            public const string StartBeforeEndDate = "The Start Date should be before End Date!";
            public const string ShouldUploadImage = "You should upload at least 1 image!";
        }

        public class Booking
        {
            public const string TripBookedSuccessfully = "The trip is booked successfully!";
            public const string AlreadyBooked = "Trip is booked already!";
            public const string AdultsOver18 = "Adults (18+)";
            public const string ChildrenBetween2And17Y = "Children (2-17 years)";
            public const string ChildrenBetween6And23M = "Infants (6-23 months)";
            public const int MinimumAdults = 1;
            public const int MaximumAdults = 4;
        }

        public class Destination
        {
            public const string DestinationAdded = "Destination added successfully!";
            public const string DestinationAlreadyExist = "Destination already exist!";
            public const string DestinationCannotBeNull = "Destination cannot be null!";
            public const string EnterDestinationName = "Please enter destination name!";
            public const string EnterDestinationDescription = "Please enter destination description!";
            public const string StartPoint = "Start Point";
            public const string EndPoint = "End Point";
            public const int MinimumNameLength = 3;
            public const int MaximumNameLength = 30;
            public const int MinimumDescriptionLength = 10;
            public const int MaximumDescriptionLength = 200;
        }

        public class City
        {
            public const string CityAdded = "City added successfully!";
            public const string CityAlreadyExist = "City already exist!";
            public const string EnterCityName = "Please enter city name!";
            public const string EnterCityDescription = "Please enter city description!";
            public const string EnterCityImage = "Please enter imageUrl.";
            public const int MinimumNameLength = 3;
            public const int MaximumNameLength = 30;
            public const int MinimumDescriptionLength = 10;
            public const int MaximumDescriptionLength = 200;
        }

        public class Country
        {
            public const string CountryName = "Country";
        }

        public class Ship
        {
            public const string ShipName = "Ship";
            public const string ShipIsBusy = "This ship is busy on this date!";
            public const string ShipCannotBeNull = "Ship cannot be null!";
        }
    }
}
