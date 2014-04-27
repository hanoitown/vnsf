using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Authorization
{
    public class ResourceType
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string ResourceFinder { get; set; }
        public string Description { get; set; }

        public ICollection<Operation> Actions { get; set; }
        public ICollection<ResourceSubject> Resources { get; set; }

    }
}
