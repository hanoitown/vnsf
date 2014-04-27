using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class JobDescription
    {
        public JobTitle Position { get; set; }
        public string Description { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
