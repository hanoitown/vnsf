using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class CategoryListViewModel 
    {

        public Guid ClassificationId { get; set; }
        public IEnumerable<CategoryManageViewModel> Categories { get; set; }
    }
}