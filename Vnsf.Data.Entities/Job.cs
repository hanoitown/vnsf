using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Job : BaseBusiness
    {
        public virtual string Position { get; set; }
        public string QuitReseason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Company { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
