using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Configuration
{
    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            this.ToTable("Region", "vnsf");
            this.HasKey(o => o.Id);
            this.Property(o => o.PhoneCode)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
    public class RegionLocalizedConfiguration : EntityTypeConfiguration<RegionLocalized>
    {
        public RegionLocalizedConfiguration()
        {
            this.ToTable("RegionLocalized", "vnsf");
            this.HasKey(o => new { o.RegionId, o.CultureId });

            this.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
