using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.Entities.KPIs
{
    public class KPI
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Rating Rate { get; set; }
        public string Reason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual UserAccount Evaluator { get; set; }
    }

    public enum Rating
    {
        A,
        B,
        C,
        D
    }
}
