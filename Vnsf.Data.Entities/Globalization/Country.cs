using System;
using System.Collections.Generic;

namespace Vnsf.Data.Entities.Globalization
{
    public class Country
    {
        public virtual Guid Id { get; set; }
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<Culture> Cultures { get; set; }
        public virtual ICollection<CountryLocalized> Localizeds { get; set; }
        public Country()
        {
            Regions = new List<Region>();
            Cultures = new List<Culture>();
            Localizeds = new List<CountryLocalized>();
        }

    }
    public class CountryLocalized
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual Culture DestCulture { get; set; }
    }
}
