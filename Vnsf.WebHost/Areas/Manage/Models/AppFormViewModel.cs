using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Registration;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class AppFormViewModel : IMapFrom<ApplicationForm>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Code { get; set; } // KHTN_V1
        public string Name { get; set; }
        public string Description { get; set; }
        public string OpportunityName { get; set; }
    }
}