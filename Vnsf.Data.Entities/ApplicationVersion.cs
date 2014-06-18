using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class ApplicationVersion
    {
        public int Duration { get; set; }
        public decimal BudgetTotal { set; get; }
        public decimal BudgetApply { get; set; }
        public string Status { get; set; } //completed / NOT
        public Guid OpportunityId { get; set; }
        public virtual Opportunity Opportunity { get; set; }
        public virtual Organization LeadingOrganization { get; set; }
        public virtual ICollection<ResearchMember> Members { get; set; }
        public virtual ICollection<ProposePublication> Publications { get; set; }
        public virtual ICollection<ProposeEducation> Educations { set; get; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual Application Application { get; set; }



    }
}
