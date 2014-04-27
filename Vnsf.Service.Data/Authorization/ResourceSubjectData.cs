using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Service.Data.Authorization
{
    public class ResourceSubjectData
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public ResourceTypeData ResourceType { get; set; }
        public string Description { get; set; }

        public ICollection<OperationData> Actions { get; set; }

    }
}
