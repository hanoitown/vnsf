using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Vnsf.Data.Entities.Globalization
{
    public class Culture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public virtual ICollection<LocalizedCulture> Localizeds { set; get; }

        public Culture()
        {
            this.Localizeds = new List<LocalizedCulture>();
        }

        public static Culture New(string name, string code, string iso2, string iso3)
        {
            return new Culture
            {
                Id = Guid.NewGuid(),
                Name = name,
                Code = code,
                ISO2 = iso2,
                ISO3 = iso3
            };
        }

        public void AddLocale(string name, Culture dest)
        {
            this.Localizeds.Add(new LocalizedCulture
            {
                Id = Guid.NewGuid(),
                Name = name,
                DestCulture = dest
            });
        }

    }


    public class LocalizedCulture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Culture DestCulture { set; get; }
        public virtual Culture Culture { set; get; }

    }
}
