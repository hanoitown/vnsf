using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Registration;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppFormViewModel : IMapFrom<ApplicationForm>
    {
        public Guid Id { get; set; }
        public string Code { get; set; } // KHTN_V1
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
