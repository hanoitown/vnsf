using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class GrantViewModel : IMapFrom<Grant>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string Scope { get; set; }
        public bool IsActive { get; set; }
        public long Total { set; get; }
        public DateTime? LastUpdated { set; get; }
        public List<OppViewModel> Opportunities { get; set; }
        public GrantViewModel()
        {

        }
    }
}