using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Opportunity : BaseBusiness
    {
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int MaxDuration { get; set; }
        public decimal EstimateTotal { get; set; }
        public decimal AwardCeiling { get; set; }
        public decimal AwardFloor { get; set; }
        public OpportunityStatus Status { get; set; }
        public virtual Grant Grant { get; set; }
        public Classification Classification{ get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Award> Awards { set; get; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<ApplicationItem> ApplicationPackage { get; set; }
        
        public Opportunity()
            : base()
        {
            Announcements = new List<Announcement>();
            Applications = new List<Application>();
            Awards = new List<Award>();
            Contracts = new List<Contract>();
        }
    }
}
