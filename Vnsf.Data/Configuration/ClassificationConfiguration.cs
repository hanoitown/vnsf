using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configuration
{
    internal class ClassificationConfiguration : EntityTypeConfiguration<Classification>
    {
        public ClassificationConfiguration()
        {
            this.HasMany(c => c.Categories).WithRequired(c => c.Classification).WillCascadeOnDelete();
        }
    }
}
