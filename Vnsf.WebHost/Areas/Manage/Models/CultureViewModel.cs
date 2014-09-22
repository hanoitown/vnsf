using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities.Globalization;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CultureViewModel : IMapFrom<Culture>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
    }
}