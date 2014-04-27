using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class EvaluationValue : BaseBusiness
    {
        public EvaluationScale Scale { get; set; }
        public string Value { get; set; }
    }
}
