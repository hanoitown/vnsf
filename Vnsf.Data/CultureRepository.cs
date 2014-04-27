using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Data.Repository;

namespace Vnsf.Data.EF
{
    public class CultureRepository : Repository<Culture>, ICultureRepository
    {

        public CultureRepository(DbContext context) : base(context) { }

        public IEnumerable<Culture> GetCultures()
        {
            return this.GetAll();
        }

    }
}
