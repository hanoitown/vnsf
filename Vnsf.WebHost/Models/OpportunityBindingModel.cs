using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;

namespace Vnsf.WebHost.Models
{
    public class OpportunityBindingModel
    {
        public Opportunity Opportunity { get; set; }
        public IEnumerable<SelectListItem> Grants { get; set; }
        public IEnumerable<SelectListItem> Classifications { get; set; }
        public OpportunityBindingModel(Opportunity opp, IEnumerable<Grant> grants, IEnumerable<Classification> classifications)
        {
            Opportunity = opp;
            Grants = grants.ToSelectList(g => g.Id.ToString(), g => g.Name, opp.GrantId.ToString());
            Classifications = classifications.ToSelectList(c => c.Id.ToString(), c => c.Name, opp.ClassificationId.ToString());
        }
    }
}