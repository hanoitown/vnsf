using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class ProposalBindingModel : IMapFrom<Proposal>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public ProposalType Kind { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        [UIHint("Number")]
        public int Duration { get; set; }
        [UIHint("Number")]
        public long TotalBudget { set; get; }
        [UIHint("Number")]
        public long RequetBudget { get; set; }
        public string Content { set; get; }
        
        public Guid FieldId { get; set; }
        public Guid? HostingId { get; set; }

    }
}
