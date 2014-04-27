using System;
using System.Collections.Generic;

namespace Vnsf.Service.Data.Authorization
{
    public class ResourceTypeData
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string ResourceFinder { get; set; }
        public string Description { get; set; }

        public ICollection<OperationData> Actions { get; set; }
        public ICollection<ResourceSubjectData> Resources { get; set; }

    }
}
