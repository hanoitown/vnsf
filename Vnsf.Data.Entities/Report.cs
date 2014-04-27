using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Report : BaseBusiness
    {
        public Category Category { get; set; }
        public string Status { get; set; }
        public DateTime DeadLine { get; set; }
        public virtual Category ReportCategory { get; set; }
        public virtual ICollection<ReportVersion> Versions { get; set; }
    }
}
