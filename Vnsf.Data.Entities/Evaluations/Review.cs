using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Review : BaseBusiness
    {
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public virtual Panel Panel { get; set; } //assign by
        //assign to public virtual Researcher Reviewer { get; set; } 
        public virtual Application Application { get; set; } //things
        public virtual ICollection<ReviewVersion> Versions { get; set; }

    }
}
