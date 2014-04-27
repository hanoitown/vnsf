using System;
using System.Collections.Generic;

namespace Vnsf.Data.Entities.Globalization
{
    public class Country
    {
        public int Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }

        private ICollection<CountryLocalized> _localizations;
        public virtual ICollection<CountryLocalized> Localizations
        {
            get { return this._localizations ?? (this._localizations = new List<CountryLocalized>()); }
            set
            {
                this._localizations = value;
            }
        }

        private ICollection<Culture> _cultures;
        public virtual ICollection<Culture> Cultures
        {
            get { return this._cultures ?? (this._cultures = new List<Culture>()); }
            set
            {
                this._cultures = value;
            }
        }

        private ICollection<Region> _regions;
        public virtual ICollection<Region> Regions
        {
            get { return this._regions ?? (this._regions = new List<Region>()); }
            set
            {
                this._regions = value;
            }
        }


    }
    public class CountryLocalized
    {
        public  Int32 CountryId { get; set; }
        public  Int32 CultureId { get; set; }
        public  String Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
