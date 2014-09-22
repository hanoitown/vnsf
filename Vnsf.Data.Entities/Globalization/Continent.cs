using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Globalization
{
    public class Continent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<ContinentLocalized> Localizeds { get; set; }
        public Continent()
        {
            Countries = new List<Country>();
            Localizeds = new List<ContinentLocalized>();
        }
    }

    public class ContinentLocalized
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Culture DestCulture { get; set; }
        public virtual Continent Continent { get; set; }
    }
}
