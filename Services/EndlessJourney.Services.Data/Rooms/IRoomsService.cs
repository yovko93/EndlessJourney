namespace EndlessJourney.Services.Data.Rooms
{
    using System.Collections.Generic;

    public interface IRoomsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
