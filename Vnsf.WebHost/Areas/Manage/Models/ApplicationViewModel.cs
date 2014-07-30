using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class ApplicationManageViewModel : IMapFrom<Application>
    {
        public Guid Id { get; set; }
        public ApplicationStatus Status { get; set; }
        public Guid OpportunityId { get; set; }
        public string ApplicantUsername { get; set; }
        public string OpportunityName { get; set; }
        public ProposalManageViewModel Proposal { set; get; }
        public DateTime? Created { set; get; }
        public DateTime? LastUpdated { get; set; }
    }
}