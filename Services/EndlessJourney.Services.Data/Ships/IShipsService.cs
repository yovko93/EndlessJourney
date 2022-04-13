namespace EndlessJourney.Services.Data.Ships
{
    using System.Collections.Generic;

    public interface IShipsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
