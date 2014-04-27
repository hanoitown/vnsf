using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class MeasurementUnit : BaseBusiness
    {
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
