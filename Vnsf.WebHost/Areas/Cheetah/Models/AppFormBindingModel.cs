using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities.Registration;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppFormBindingModel : IHaveCustomMapping
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Code { get; set; } // KHTN_V1
        public string Name { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase File { get; set; }


        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            AutoMapper.Mapper.CreateMap<ApplicationForm, AppFormBindingModel>()
                .ForMember(d => d.File, opt => opt.Ignore());
        }
    }
}