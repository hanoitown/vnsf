using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class AgencyViewModel : IMapFrom<FundingAgency>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}