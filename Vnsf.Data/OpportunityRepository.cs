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
    public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(DbContext context) : base(context) { }
        public IQueryable<Opportunity> GetAvailableOpportunities()
        {
            return this.DbSet.Include(o=>o.Applications).Include(o=>o.Grant).Include(o=>o.Classification);
        }


    }
}
