using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class CategoryViewModel : IHaveCustomMapping
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public Guid ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public string ParentName { set; get; }
        public int Depth { get; set; }

        public List<CategoryViewModel> Children { get; set; }
        public CategoryViewModel()
        {
            Children = new List<CategoryViewModel>();
        }

        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(d => d.Children, opt => opt.Ignore());
        }

    }
}
