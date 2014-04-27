using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.Repository
{
    public interface IGrantRepository : IRepository<Grant>
    {
        ICollection<Budget> GetBudgetByGrandId(Guid id);
        void DeleteBudget(Guid BudgetId, Guid OrganizationId);
        IQueryable<Grant> GetAvailableGrant();
        Grant GetGrantDetailById(Guid id);
        IQueryable<Opportunity> GetOpportunityHistory(Guid Id);
    }
}
