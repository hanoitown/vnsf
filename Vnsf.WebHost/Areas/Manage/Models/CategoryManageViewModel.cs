using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CategoryManageViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ClassificationManageViewModel Classification { get; set; }

    }
}
