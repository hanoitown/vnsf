using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class ProposalManageViewModel : IMapFrom<Proposal>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public CategoryManageViewModel Field { get; set; }
        public ProposalType Kind { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Duration { get; set; }
        public long TotalBudget { set; get; }
        public long RequetBudget { get; set; }
        public string Content { set; get; }

    }
}
