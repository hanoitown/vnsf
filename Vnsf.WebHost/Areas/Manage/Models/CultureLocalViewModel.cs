using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities.Globalization;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CultureLocalViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Vietnamese
        public string CultureName { get; set; } // Tieng Viet        
    }
}