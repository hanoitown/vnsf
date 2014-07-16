using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities.Reports
{
    public class ReportColaboration
    {
        public Guid Id { get; set; }
        public string Contribution { get; set; }
        public virtual Report Report { get; set; }
        public virtual Organization Organization { get; set; }
        
    }
}
