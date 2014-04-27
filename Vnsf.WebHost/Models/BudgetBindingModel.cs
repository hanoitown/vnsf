using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models
{
    public class BudgetBindingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public int FinancialYear { set; get; }
        public decimal Amount { set; get; }
        public Guid SupplierId { set; get; }
        
    }
}