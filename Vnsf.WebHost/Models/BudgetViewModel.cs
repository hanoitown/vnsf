using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models
{
    public class BudgetViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { set; get; }
        public decimal Amount { set; get; }
        public string Supplier { set; get; }
    }
}