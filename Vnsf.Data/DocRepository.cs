using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Data.Repository;

namespace Vnsf.Data.EF
{
    public class DocRepository : Repository<Doc>, IDocRepository
    {
        public DocRepository(DbContext context) : base(context) { }

        public IEnumerable<Doc> getHierachy(Guid id)
        {
            var list = new List<Doc>();
            var doc = DbSet.Find(id);
            list.Add(doc);

            var parent = doc.Container;
            while (parent != null)
            {
                list.Insert(0, parent);
                parent = parent.Container;
            }

            return list;
        }
    }
}
