using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Registration;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Opportunity : Audit
    {
        public static Opportunity NewOpportunity(Grant grant, string name, string description, int? numOfAward, long? totalAward, DateTime startDate, DateTime deadline)
        {
            return new Opportunity()
            {
                Id = Guid.NewGuid(),
                Grant = grant,
                Name = name,
                Description = description,
                NumberOfAward = numOfAward,
                TotalAward = totalAward,
                StartDate = startDate,
                Deadline = deadline
            };
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NumberOfAward { get; set; }
        public long? TotalAward { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public virtual Grant Grant { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Award> Awards { set; get; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<ApplicationForm> ApplicationPackage { get; set; }

        public Opportunity()
        {
            ApplicationPackage = new List<ApplicationForm>();
            Announcements = new List<Announcement>();
            Applications = new List<Application>();
            Awards = new List<Award>();
            Contracts = new List<Contract>();
        }

        //public static void AddForm(ApplicationForm form)
    }
}
