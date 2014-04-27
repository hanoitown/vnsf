using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities.Globalization;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class LocalizedCultureViewModel : IMapFrom<Culture>
    {
        public string Code { get; set; } // vi-VN
    }
}