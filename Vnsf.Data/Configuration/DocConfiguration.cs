using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configuration
{
    internal class DocConfiguration : EntityTypeConfiguration<Doc>
    {
        public DocConfiguration()
        {
            this.HasOptional(d => d.Container);
            this.HasOptional(d => d.CreatedBy).WithMany().WillCascadeOnDelete(false);
            this.HasOptional(d => d.LastUpdatedBy).WithMany().WillCascadeOnDelete(false);
        }
    }
}
