using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Globalization
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }             
        public virtual Country Country { get; set; }
        public virtual ICollection<RegionLocalized> Localizeds { get; set; }
        public Region()
        {
            Localizeds = new List<RegionLocalized>();
        }
    }

    public class RegionLocalized
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Culture DestCulture { get; set; }
        public virtual Region Region { get; set; }
    }

}
