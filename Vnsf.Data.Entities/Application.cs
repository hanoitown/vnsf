using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Application 
    {
        public Guid Id { get; set; }
        public ApplicationStatus Status { get; set; } // submitted / withdraw / return / overdue
        public decimal BudgetTotal { set; get; }
        public decimal BudgetApply { get; set; }

        public Guid OpportunityId { get; set; }
        public virtual Opportunity Opportunity { get; set; }

        //public virtual UserAccount Applicant{ get; set; }


        public Application()
        {
            
        }
        public void Init(Opportunity opportunity, UserAccount userAccount)
        {
            Id = Guid.NewGuid();
            Opportunity = opportunity;
            //Applicant = userAccount;
 
            Status = ApplicationStatus.Creating;
        }
    }
}
