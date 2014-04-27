using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Authorization
{
    public class AuthorizationPolicy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PolicyEffect PolicyEffect { get; set; } // grant/deny
        public Principle Principle { get; set; }
        public ResourceType ResourceType { get; set; }
        public Operation Target { get; set; }
    }
}
