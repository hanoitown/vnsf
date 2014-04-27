using System;
using System.Security.AccessControl;

namespace Vnsf.Service.Data.Authorization
{
    public class OperationData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}
