using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class UserProfileBindingModel : IHaveCustomMapping
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string AvatarAlias { get; set; }
        public HttpPostedFileBase AvatarFile { get; set; }
        public ICollection<EducationViewModel> Educations { set; get; }
        public ICollection<PublicationViewModel> Publications { set; get; }
        public ICollection<JobViewModel> WorkExperiences { set; get; }
        public ICollection<ProjectViewModel> Projects { set; get; }
        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            AutoMapper.Mapper.CreateMap<UserProfile, UserProfileBindingModel>()
                .ForMember(d => d.AvatarFile, opt => opt.Ignore());
        }

    }
}