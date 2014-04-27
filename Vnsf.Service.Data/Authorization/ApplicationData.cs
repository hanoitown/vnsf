using System;
using System.Collections.Generic;

namespace Vnsf.Service.Data.Authorization
{
    public class ApplicationData
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<AuthorizationPolicyData> Policies { get; set; }
        public ICollection<ResourceTypeData> ResourceTypes { get; set; }
        public ICollection<AppRoleData> AppRoles { get; set; }

        public void AddResourceType(ResourceTypeData item)
        {
            ResourceTypes.Add(item);
        }

        public void AddAppRoles(AppRoleData role)
        {
            AppRoles.Add(role);
        }

    }
}
