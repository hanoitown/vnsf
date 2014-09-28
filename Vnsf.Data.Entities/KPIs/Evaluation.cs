using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.KPIs
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public UserProfile User { get; set; }
        public ICollection<KPI> Indicators { get; set; }
    }
}
