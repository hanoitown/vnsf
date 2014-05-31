using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configurations
{
    internal class DocConfiguration : EntityTypeConfiguration<Doc>
    {
        public DocConfiguration()
        {
            this.HasOptional(d => d.Parent);
            this.HasOptional(d => d.Link).WithRequired(l => l.Document);
        }
    }
}
