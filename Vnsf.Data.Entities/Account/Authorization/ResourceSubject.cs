using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Authorization
{
    public class ResourceSubject
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Description { get; set; }

        public ICollection<Operation> Actions { get; set; }

    }
}
