using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppViewModel : IMapFrom<Application>
    {
        public ApplicationStatus Status { get; set; } // submitted / withdraw / return / overdue
        public ProposalViewModel Proposal { get; set; }

        public virtual OppViewModel Opportunity { get; set; }
        public virtual UserViewModel Applicant { get; set; }

        public string OpportunityName { get; set; }
        public string OpportunityDescription { get; set; }
        public List<AppDocumentViewModel> Documents { get; set; }


    }
}