using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ChangeRequest : BaseBusiness
    {
        public Category Category { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}
