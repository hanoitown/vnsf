using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class PanelMemberRole : BaseBusiness
    {
        public virtual ICollection<PanelMember> Members { get; set; }
    }
}
