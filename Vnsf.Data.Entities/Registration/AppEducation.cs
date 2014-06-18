using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class AppEducation : BaseBusiness
    {
        public int Quantity { get; set; }
        public EducationLevel Level { get; set; }
        public virtual Organization School { get; set; }
    }
}
