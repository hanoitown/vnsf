using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class PanelEvaluation : BaseBusiness
    {
        public virtual Application Application { get; set; }
        public virtual PanelMember Member { get; set; }
        public virtual ReviewDetail Result { get; set; }
    }
}
