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
    public class GrantRepository : Repository<Grant>, IGrantRepository
    {
        public GrantRepository(DbContext context) : base(context) { }

        public Grant GetGrantDetailById(Guid id)
        {
            return this.DbSet.Include(g => g.Opportunities).FirstOrDefault(g => g.Id == id);
        }
        public ICollection<Budget> GetBudgetByGrandId(Guid id)
        {
            //return this.DbSet.Where(g => g.Id == id).Include(g => g.Budgets).FirstOrDefault().Budgets;
            return null;
        }

        public void DeleteBudget(Guid BudgetId, Guid OrganizationId)
        {
            throw new NotImplementedException();
        }



        public IQueryable<Grant> GetAvailableGrant()
        {
            return this.DbSet.Include(g => g.Opportunities);
        }

        public IQueryable<Opportunity> GetOpportunityHistory(Guid Id)
        {
            var grant = this.DbSet.Include(g => g.Opportunities).Where(g => g.Id == Id).FirstOrDefault();
            if (grant == null)
            {
                return null;
            }
            else
                return grant.Opportunities.AsQueryable();
        }
    }

}
