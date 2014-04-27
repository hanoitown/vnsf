using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class OpportunityViewModel : IMapFrom<Opportunity>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxDuration { get; set; }
        public decimal EstimateTotal { get; set; }
        public decimal AwardCeiling { get; set; }
        public decimal AwardFloor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public string GrantName { get; set; }
        public OpportunityViewModel()
        {

        }
        public OpportunityViewModel(Opportunity o)
        {
            Id = o.Id;
            Name = o.Name;
            Description = o.Description;
            MaxDuration = o.MaxDuration;
            EstimateTotal = o.EstimateTotal;
            AwardCeiling = o.AwardCeiling;
            AwardFloor = o.AwardFloor;
            StartDate = o.StartDate;
            Deadline = o.Deadline;
            GrantName = o.Grant != null ? o.Grant.Name : string.Empty;
        }
    }
}