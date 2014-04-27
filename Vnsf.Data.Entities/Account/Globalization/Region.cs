using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Globalization
{
    public class Region
    {
        public virtual int Id { get; set; }
        public virtual string PhoneCode { get; set; }

        public virtual int CountryId { get; set; }
        public virtual Country Country { get; set; }

        private ICollection<RegionLocalized> _localizations;
        public virtual ICollection<RegionLocalized> Localizations
        {
            get { return this._localizations ?? (this._localizations = new List<RegionLocalized>()); }
            set
            {
                this._localizations = value;
            }
        }
    }

    public class RegionLocalized
    {
        public virtual Int32 RegionId { get; set; }
        public virtual Int32 CultureId { get; set; }
        public virtual String Name { get; set; }
        public virtual Culture Culture { get; set; }
        public virtual Region Region { get; set; }
    }

}
