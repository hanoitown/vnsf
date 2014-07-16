using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ReviewVersion 
    {
        public virtual Review Review { get; set; }
        public virtual Classification Template { get; set; }
        public virtual ICollection<ReviewDetail> Reviews { get; set; }

    }
}
