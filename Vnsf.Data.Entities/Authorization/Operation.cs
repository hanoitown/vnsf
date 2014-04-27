using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Authorization
{
    public class Operation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}
