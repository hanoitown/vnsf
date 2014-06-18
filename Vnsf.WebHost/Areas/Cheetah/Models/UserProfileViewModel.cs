using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class UserProfileViewModel : IMapFrom<UserProfile>
    {
        public Guid Id { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Gender { get; set; }

    }
}
