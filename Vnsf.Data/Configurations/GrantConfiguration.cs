using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configurations
{
    internal class GrantConfiguration : EntityTypeConfiguration<Grant>
    {
        public GrantConfiguration()
        {
            //this.HasMany(o => o.Budgets)
            //       .WithRequired(o => o.Grant)
            //        .WillCascadeOnDelete(true);            
        }
    }
}
