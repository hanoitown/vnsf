using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.HRM
{
    public class OrganizationUnit
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public Person Manager { get; set; }
        public Guid ParentUnit { get; set; }
    }
}
