using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities.Account;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class UserAccountViewModel : IMapFrom<UserAccount>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime LastUpdated { get; internal set; }

    }
}