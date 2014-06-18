using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class OppViewModel : IMapFrom<Opportunity>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NumberOfAward { get; set; }
        public long? TotalAward { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        //public GrantViewModel Grant { get; set; }
        public string GrantCode { get; set; }
        public string GrantName { get; set; }
        public string GrantDescription { get; set; }
        public string GrantObjective { get; set; }
        public string GrantScope { get; set; }
        public bool GrantIsActive { get; set; }
        public long GrantTotal { set; get; }
        //public bool IsApplied { get; set; }

    }
}