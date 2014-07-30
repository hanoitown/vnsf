using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Evaluations;
using Vnsf.Data.Entities.Registration;
using Vnsf.Data.Entities.Proposals;

namespace Vnsf.Data.Entities
{
    public class Proposal
    {
        public static Proposal New(string title, string pabstract, DateTime startDate, DateTime finishDate, int duration, long totalBudget, long requestBudget, string content)
        {
            return new Proposal()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Abstract = pabstract,
                StartDate = startDate,
                FinishDate = finishDate,
                Duration = duration,
                TotalBudget = totalBudget,
                RequetBudget = requestBudget,
                Content = content
            };
        }


        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public ProposalType Kind { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Duration { get; set; }
        public long TotalBudget { set; get; }
        public long RequetBudget { get; set; }
        public string Content { set; get; }
        public virtual Category Field { get; set; }
        public virtual Organization Hosting { get; set; } // To chuc chu tri

        public virtual ICollection<ProposalProduct> Products { get; set; }
        public virtual ICollection<ProposalEducation> Educations { set; get; }
        public virtual ICollection<Participation> Participants { get; set; }
        public virtual ICollection<ProposalColaboration> Colaborations { get; set; }
        public virtual ICollection<ApplicationDocument> Documents { get; set; }
        public virtual ICollection<Reviewer> Reviewers { get; set; }
        public virtual Application Application { get; set; }


        //Link property to shortcut the reporting query
        public virtual ICollection<Report> Reports { get; set; }


        public Proposal()
        {
            Products = new List<ProposalProduct>();
            Educations = new List<ProposalEducation>();
            Documents = new List<ApplicationDocument>();
            Colaborations = new List<ProposalColaboration>();
            Reviewers = new List<Reviewer>();
            Participants = new List<Participation>();
        }


        public static Proposal Create(Application application)
        {
            return new Proposal()
            {
                Id = Guid.NewGuid(),
                Application = application
            };
        }

        public static Proposal Clone(Proposal proposal)
        {
            return null;
        }
    }

    public enum ProposalType
    {
        Theory,
        Experimental
    }
}
