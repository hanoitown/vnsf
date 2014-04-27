using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;

namespace Vnsf.Data.EF
{
    public class ClassificationRepository : Repository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(DbContext context) : base(context) { }



        public Classification GetClassificationById(Guid id)
        {
            return this.DbSet.Include(c => c.Categories).FirstOrDefault(c => c.Id == id);
        }
    }
}
