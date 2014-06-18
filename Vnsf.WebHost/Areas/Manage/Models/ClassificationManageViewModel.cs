using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class ClassificationManageViewModel:IMapFrom<Classification>
    {
        public virtual Guid Id { set; get; }
        public string Code { get; set; }
        public virtual string Name { set; get; }
        public virtual string Description { set; get; }

    }
}
