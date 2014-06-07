using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppBindingModel : IHaveCustomMapping
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public List<HttpPostedFileBase> File { get; set; }
        public OppViewModel Opportunity { set; get; }
        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Application, AppBindingModel>()
                .ForMember(d => d.File, opt => opt.Ignore());

        }


    }
}