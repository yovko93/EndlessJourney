namespace EndlessJourney.Data.Models
{
    using System.Collections.Generic;

    using EndlessJourney.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public string Name { get; set; }

        public string Capital { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
