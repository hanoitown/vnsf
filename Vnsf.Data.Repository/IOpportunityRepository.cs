using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.Repository
{
    public interface IOpportunityRepository : IRepository<Opportunity>
    {
        IQueryable<Opportunity> GetAvailableOpportunities();
    }
}
