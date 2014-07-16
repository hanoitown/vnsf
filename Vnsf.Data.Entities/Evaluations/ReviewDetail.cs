using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ReviewDetail : BaseBusiness
    {
        public string Opinion { get; set; }
        public virtual ReviewVersion Review { get; set; }
        public EvaluationScale Scale { get; set; }
        public EvaluationValue Grade { get; set; }
    }
}
