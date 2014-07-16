using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;

namespace Vnsf.Data.EF.Configurations
{
    public class AwardConfiguration : EntityTypeConfiguration<Award>
    {
        public AwardConfiguration()
        {
            HasOptional(a => a.Contract).WithRequired(c => c.Award);
        }
    }
}
