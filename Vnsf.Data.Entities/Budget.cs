using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    /// <summary>
    /// Is object depended on Grant object. It is not "BaseBusiness" actually
    /// </summary>
    public class Budget
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid OpportunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FinancialYear { set; get; }
        public decimal Amount { set; get; }
        public virtual Opportunity Opportunity { set; get; }
        public virtual Organization Supplier { set; get; }

        public Budget()
        {

        }

        //TODO: Remove based object and add/remove neccessary fields
    }
}
