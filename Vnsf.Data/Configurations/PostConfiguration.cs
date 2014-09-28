using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Configurations
{
    internal class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {

            this.HasMany(o => o.Locales)
                .WithRequired(o => o.Post);
        }
    }
}