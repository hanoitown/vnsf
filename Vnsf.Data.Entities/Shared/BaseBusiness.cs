using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities
{
    public abstract class BaseBusiness : BaseAudit
    {
        public virtual Guid Id { set; get; }
        public virtual string Name { set; get; }
        public virtual string Description { set; get; }
        public virtual IEnumerable<LocalizedBaseBusiness> Localizeds { get; set; }


        public BaseBusiness()
        {
            Id = Guid.NewGuid();
        }

        public virtual void GetLocalized(Guid cultureId)
        {
            var localized = Localizeds.FirstOrDefault(l => l.CultureId == cultureId);
            if (localized != null)
            {

                this.Name = localized.Name ?? localized.Name;
                this.Description = localized.Description ?? localized.Description;
            }
        }
    }

    public abstract class LocalizedBaseBusiness
    {
        public virtual Guid Id { get; set; } //dataId
        public virtual Guid CultureId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Culture Culture { set; get; }

    }
}
