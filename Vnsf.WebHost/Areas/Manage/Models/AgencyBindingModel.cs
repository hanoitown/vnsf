using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class AgencyBindingModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}