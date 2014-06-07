using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configurations
{
    internal class OpportunityConfiguration : EntityTypeConfiguration<Opportunity>
    {
        public OpportunityConfiguration()
        {
            this.HasMany(g => g.ApplicationPackage).WithRequired(o => o.Opportunity).WillCascadeOnDelete(true);
        }
    }
}
