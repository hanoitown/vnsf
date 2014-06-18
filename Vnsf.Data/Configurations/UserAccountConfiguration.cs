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
    public class UserAccountConfiguration : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountConfiguration()
        {
            this.HasMany(u => u.Applications).WithRequired(a => a.Applicant).WillCascadeOnDelete(false);
            this.HasOptional(u => u.Profile).WithRequired(p => p.Account);
        }
    }
}
