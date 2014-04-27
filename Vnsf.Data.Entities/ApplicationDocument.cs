using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ApplicationDocument : BaseBusiness
    {
        public Application Application { get; set; }
        public Doc Document { get; set; }
        public Category Category { get; set; }
    }
}
