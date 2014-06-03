using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClassificationName { get; set; }
        public CategoryViewModel()
        {
            
        }
    }
}