using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Configuration
{
    public class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            this.ToTable("Language", "vnsf");

            this.HasKey(o => o.Id);

            this.HasMany(c => c.Cultures)
                .WithOptional(l => l.Language);

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
    public class LanguageLocalizedConfiguration : EntityTypeConfiguration<LanguageLocalized>
    {
        public LanguageLocalizedConfiguration()
        {
            this.ToTable("LanguageLocalized", "vnsf");
            this.HasKey(o => new { o.LanguageId, o.CultureId });

            this.Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }


}
