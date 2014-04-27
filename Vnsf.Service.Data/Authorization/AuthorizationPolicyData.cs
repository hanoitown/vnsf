using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Authorization
{
    public class AuthorizationPolicyData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PrincipleData Principle { get; set; }
        public ResourceTypeData ResourceType { get; set; }
        public OperationData Target { get; set; }
    }
}
