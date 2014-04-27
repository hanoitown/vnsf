using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class OrganizationUnit
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Organization Parent { get; set; }
        //http://www.codeproject.com/Articles/2774/Modeling-Hierarchies
        public int Depth { get; set; }
    }
}
