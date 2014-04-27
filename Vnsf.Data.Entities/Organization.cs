using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public abstract class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }        
        public virtual Contact Contact { set; get; }
        public virtual Category OgranizationType { get; set; }
        public virtual ICollection<OrganizationUnit> Units { get; set; }

        public Organization()
            : base()
        {
            Units = new List<OrganizationUnit>();
        }

    }
}
