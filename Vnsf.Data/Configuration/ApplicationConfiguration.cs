using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Authorization;

namespace Vnsf.Data.Configuration
{
    public class ApplicationConfiguration : EntityTypeConfiguration<Application>
    {
        public ApplicationConfiguration()
        {
            this.ToTable("Application", "vnsf");

            this.Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

        }
    }
}
