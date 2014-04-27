using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Grant : BaseBusiness
    {
        public string Code { get; set; }
        public string Objective { get; set; }
        public int MaxDuration { get; set; }
        public double Total { set; get; }
        public int MaxAward { set; get; }
        public Guid? AgencyId { get; set; }
        public virtual FundingAgency Agency { get; set; }
        public virtual Classification ClassificationSystem { get; set; }
        public virtual Doc Logo { get; set; }
        public virtual ICollection<GrantLocalized> GrantLocalizeds { set; get; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
        public virtual ICollection<Panel> SciencePanels { get; set; }
        public Grant()
            : base()
        {
            Opportunities = new List<Opportunity>();
        }

        public virtual void Init(string code, string name, string description, double total, int maxaward)
        {
            this.Id = Guid.NewGuid();
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.Total = total;
            this.MaxAward = maxaward;
            this.Created = DateTime.Now;
        }

        // add opportunity
        public void NewOpportunity(Opportunity opp)
        {
            this.Opportunities.Add(opp);
        }

        public virtual void GetLocalizedGrant(Guid cultureId)
        {
            var localized = this.GrantLocalizeds.Where(l => l.CultureId == cultureId).FirstOrDefault();
            if (localized != null)
            {
                this.GetLocalized(cultureId);
                this.Objective = localized.Objective ?? localized.Objective;
            }
        }
    }

    public class GrantLocalized : LocalizedBaseBusiness
    {
        public virtual string Objective { get; set; }
        public GrantLocalized()
        {

        }

        public virtual void AddTranslation(string objective)
        {
            this.Objective = objective;
        }
    }
}
