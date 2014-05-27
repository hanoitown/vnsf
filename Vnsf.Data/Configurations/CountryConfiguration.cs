using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Configuration
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            this.ToTable("Country", "vnsf");

            this.HasKey(o => o.Id);

            this.HasMany(c => c.Cultures)
                .WithOptional(c => c.Country);

            this.Property(o => o.Iso2)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsUnicode(false)
                .IsRequired();

            this.Property(o => o.Iso3)
                .HasMaxLength(3)
                .IsFixedLength()
                .IsUnicode(false)
                .IsRequired();
        }
    }
    public class CountryLocalizedConfiguration : EntityTypeConfiguration<CountryLocalized>
    {
        public CountryLocalizedConfiguration()
        {
            this.ToTable("CountryLocalized", "vnsf");
            this.HasKey(o => new { o.CountryId, o.CultureId });

            this.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

