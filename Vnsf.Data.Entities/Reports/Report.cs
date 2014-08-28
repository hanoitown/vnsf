using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Proposals;
using Vnsf.Data.Entities.Shared;
using Vnsf.Data.Entities.Reports;

namespace Vnsf.Data.Entities
{
    public class Report : Audit
    {
        public static Report New(ReportKind kind)
        {
            return new Report()
            {
                Id = Guid.NewGuid(),
                Kind = kind
            };
        }

        public Guid Id { get; set; }
        public ReportKind Kind { get; set; }
        public ReportStatus Status { get; set; }
        public DateTime SubmittedDate { get; set; }

        // if change compare with proposal content
        public string Purpose { get; set; }
        public string Scope { get; set; }
        public string Methodology { get; set; }
        public string Changes { get; set; }
        public string Accomplishment { get; set; }
        public string Recommendation { get; set; }
        public string Impacts { get; set; }

        public virtual ICollection<ReportColaboration> Colaborations { set; get; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Organization> Participations { get; set; }

        public virtual Contract Contract { get; set; }

        public Report()
        {
            Publications = new List<Publication>();
            Participations = new List<Organization>();
            Colaborations = new List<ReportColaboration>();
        }
    }

    public enum ReportKind
    {
        Final,
        Midterm,
        OnDemand
    }
    public enum ReportStatus
    {
        Editing,
        Submitted,
        UnderReview,
        Completed
    }
}

