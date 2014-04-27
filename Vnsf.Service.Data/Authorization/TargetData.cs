using System;
using System.Collections.Generic;

namespace Vnsf.Service.Data.Authorization
{
    public class TargetData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<ResourceSubjectData> Resources { get; set; }
    }
}
