using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Security
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  // Read, write, download, view, change name ....
        public string Description { get; set; }
        public bool Allow { get; set; }
        public bool Deny { get; set; }
    }
}
