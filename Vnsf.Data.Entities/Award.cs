using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Award : BaseBusiness
    {        
        public string AwardDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Application Application { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        
    }
}
