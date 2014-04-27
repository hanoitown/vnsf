using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities
{
    public class Opportunity
    {
        public Guid Id { get; set; }
        public Guid IndustryId { get; set; }
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? ExtendedDate { get; set; }

    }

    public class OpportunityLocalization
    {
        public Guid FundingOpportunityId { get; set; }
        public int CultureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Announcement { get; set; }
        public string Requirements { get; set; }

        public Opportunity FundingOpportunity { get; set; }
        public Culture Culture { get; set; }
    }
}
