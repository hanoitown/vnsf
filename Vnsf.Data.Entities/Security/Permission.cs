using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Security
{
    public class Permission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Allow { get; set; }
        public bool Deny { get; set; }
    }
}
