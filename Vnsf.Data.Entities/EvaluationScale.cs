using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class EvaluationScale : BaseBusiness
    {
        public string BaseType { get; set; }
        public virtual ICollection<EvaluationValue> LegitimateValues { get; set; }
    }
}
