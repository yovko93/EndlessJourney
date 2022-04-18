namespace EndlessJourney.Services.Data.Countries
{
    using System.Collections.Generic;

    public interface ICountriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
