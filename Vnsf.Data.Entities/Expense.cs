using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Expense : BaseBusiness
    {
        public string Code { get; set; }
        public Unit Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public Category Category { get; set; }
    }
}
