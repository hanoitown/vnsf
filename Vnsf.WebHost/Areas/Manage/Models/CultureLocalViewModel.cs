using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities.Globalization;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CultureLocalViewModel : IMapFrom<LocalizedCulture>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Vietnamese
        public string DestCultureName { get; set; } // Tieng Viet        
    }
}