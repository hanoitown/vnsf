using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities.Principle;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class ProjectViewModel:IMapFrom<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public long TotalBudget { get; set; }
        public int Duration { get; set; }
        public string OtherCompany { get; set; }

    }
}