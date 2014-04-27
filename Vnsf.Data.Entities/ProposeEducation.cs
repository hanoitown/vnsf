using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ProposeEducation : BaseBusiness
    {
        public int Quantity { get; set; }
        public EducationLevel Level { get; set; }
        public ICollection<EducationDetail> Details { get; set; }
    }
}
