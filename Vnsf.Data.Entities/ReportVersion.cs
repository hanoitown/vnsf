using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ReportVersion 
    {
        public Guid Id { get; set; }
        public virtual Report Report { get; set; }
        public string Target { get; set; }
        public string Scope { get; set; }
        public string Result { get; set; }
        public string Change { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

    }
}
