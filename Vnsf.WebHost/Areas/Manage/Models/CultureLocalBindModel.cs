using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities.Globalization;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CultureLocalBindModel : IMapFrom<LocalizedCulture>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; } // Vietnamese
        public Guid DestCultureId { set; get; }
    }
}