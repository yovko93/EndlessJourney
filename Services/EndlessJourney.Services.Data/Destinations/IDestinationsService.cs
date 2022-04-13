namespace EndlessJourney.Services.Data.Destinations
{
    using System.Collections.Generic;

    public interface IDestinationsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
