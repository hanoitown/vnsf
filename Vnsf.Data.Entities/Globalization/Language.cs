using System;
using System.Collections.Generic;

namespace Vnsf.Data.Entities.Globalization
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public virtual ICollection<Culture> Cultures { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<LanguageLocalized> Localizeds { get; set; }
        public Language()
        {
            Cultures = new List<Culture>();
            Countries = new List<Country>();
            Localizeds = new List<LanguageLocalized>();
        }
    }
    public class LanguageLocalized
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Culture DestCulture { get; set; }
        public virtual Language Language { get; set; }
    }
}

