using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class EducationDetail : BaseBusiness
    {
        public int Quantity { get; set; }
        public virtual Organization School { get; set; }
    }
}
