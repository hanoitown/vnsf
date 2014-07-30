using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class UserProfileGeneralInforBindingModel : IHaveCustomMapping
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string AvatarAlias { get; set; }
        public HttpPostedFileBase AvatarFile { get; set; }
        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            AutoMapper.Mapper.CreateMap<UserProfile, UserProfileGeneralInforBindingModel>()
                .ForMember(d => d.AvatarFile, opt => opt.Ignore());
        }

    }
}