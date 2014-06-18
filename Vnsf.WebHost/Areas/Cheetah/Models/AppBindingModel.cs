using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppBindingModel : IMapFrom<Application>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public ApplicationStatus Status { set; get; }
        public OppViewModel Opportunity { set; get; }
        public ProposalBindingModel Proposal { set; get; }
        public virtual ICollection<UserProfileViewModel> Participations { get; set; }

        public UserViewModel Applicant { get; set; }
    }
}