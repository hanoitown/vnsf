using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Configurations
{
    internal class CultureConfiguration : EntityTypeConfiguration<Culture>
    {
        public CultureConfiguration()
        {
            this.ToTable("Culture", "vnsf");

            this.HasKey(o => o.Id);

            this.Property(o => o.Code)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            //this.HasOptional(o => o.Language)
            //    .WithMany(o => o.Cultures)
            //    .HasForeignKey(o => o.LanguageId)
            //    .WillCascadeOnDelete(false);

            //this.HasOptional(o => o.Country)
            //    .WithMany(o => o.Cultures)
            //    .HasForeignKey(o => o.CountryId)
            //    .WillCascadeOnDelete(false);

            this.HasMany(o => o.Localizeds)
                .WithRequired(o => o.Culture);
        }
    }

    internal class CultureLocalizedConfiguration : EntityTypeConfiguration<LocalizedCulture>
    {
        public CultureLocalizedConfiguration()
        {
            this.ToTable("CultureLocalized", "vnsf");

            this.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            //this.HasRequired(o => o.Culture)
            //    .WithMany(o => o.Localizations)
            //    .HasForeignKey(o => o.CultureId)
            //    .WillCascadeOnDelete(false);

            //this.HasRequired(o => o.LocalizedCulture)
            //    .WithMany(o => o.Localizations)
            //    .HasForeignKey(o => o.Id)
            //    .WillCascadeOnDelete(false);
        }
    }
}