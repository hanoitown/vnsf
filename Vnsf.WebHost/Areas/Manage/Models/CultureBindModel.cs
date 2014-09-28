using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities.Globalization;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CultureBindModel : IMapFrom<Culture>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
    }
}