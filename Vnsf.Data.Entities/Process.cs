using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Process : BaseBusiness
    {
        public int Duration { get; set; }
        public Organization Responsibility { get; set; }
        public virtual ICollection<BusinessDocumentType> Documents { get; set; }
        public virtual ICollection<Process> NextProcess { get; set; }
    }
}
