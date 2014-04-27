using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class ClassificationBindingModel : IMapFrom<Classification>
    {
        [HiddenInput]
        public Guid? Id { get; set; }
        [Display(ResourceType = typeof(Vnsf.Resource.WebHost.ViewModel.ClassificationBindingModel), Name = "Name", Description = "NameDescription")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}