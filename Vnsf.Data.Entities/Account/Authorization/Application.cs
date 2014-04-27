using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Authorization
{
    public class Application
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<AuthorizationPolicy> Policies { get; set; }
        public ICollection<ResourceType> ResourceTypes { get; set; }
        public ICollection<AppRole> AppRoles { get; set; }

        public Application()
        {
            ResourceTypes = new List<ResourceType>();
            AppRoles = new List<AppRole>();
            Policies = new List<AuthorizationPolicy>();
        }

    }
}
