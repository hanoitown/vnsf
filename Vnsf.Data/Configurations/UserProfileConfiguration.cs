using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.EF.Configurations
{
    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            this.HasRequired(u=>u.Account).WithOptional(u=>u.Profile);
            this.HasMany(u => u.Publications).WithRequired(p=>p.Profile);
            HasMany(u => u.Projects).WithRequired(p => p.Profile);
            HasMany(u => u.WorkExperiences).WithRequired(p => p.Profile);
        }
    }
}
