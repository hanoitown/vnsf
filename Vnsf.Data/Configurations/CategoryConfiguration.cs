using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configurations
{
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {

            //this.HasMany(o => o.Hierachy)
            //    .WithRequired(o => o.Category)
            //    .WillCascadeOnDelete(false);
        }
    }
}
