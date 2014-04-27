using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Panel : BaseBusiness
    {
        // usually 5 year duration
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<PanelMember> Members { get; set; }
        public virtual Opportunity Opportunity { get; set; }

    }
}
