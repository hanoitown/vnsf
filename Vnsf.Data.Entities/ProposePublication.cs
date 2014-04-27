using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ProposePublication : BaseBusiness
    {
        public int Quantity { get; set; }
        public virtual Category Category { get; set; }
    }
}
