using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Areas.Cheetah.Models;
using Vnsf.WebHost.Base;
using AutoMapper.QueryableExtensions;
using Vnsf.WebHost.Models;
using Vnsf.WebHost.Models.Document;
using Vnsf.WebHost.Infrastructure;
using System.Diagnostics;
using Vnsf.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class UserProfileController : MvcBaseController
    {
        ICurrentUser _user;
        public UserProfileController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }

        public ActionResult Index()
        {
            var profile = _uow.Profiles.AllIncluding(p => p.Account,
                                                        p => p.Educations,
                                                        p => p.Publications,
                                                        p => p.WorkExperiences,
                                                        p => p.Projects)
                                        .FirstOrDefault(p => p.Id == _user.User.Id);


            var vm = AutoMapper.Mapper.Map<UserProfileBindingModel>(profile);


            return View(vm);
        }

        public ActionResult NewGeneralInfo()
        {
            var profile = _uow.Profiles.All
                                        .FirstOrDefault(p => p.Id == _user.User.Id);

            var vm = AutoMapper.Mapper.Map<UserProfileGeneralInforBindingModel>(profile);

            return View(vm);
        }


        [HttpPost]
        public ActionResult NewGeneralInfo(UserProfileGeneralInforBindingModel form)
        {
            var profile = _uow.Profiles.AllIncluding(p => p.Account).FirstOrDefault(p => p.Account.Id == _user.User.Id);
            profile.Name = new FullName(form.NameFirst, form.NameLast);
            profile.BirthDay = form.Birthday;
            profile.Gender = form.Gender;

            _uow.Save();

            return RedirectToAction<UserProfileController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var profile = _uow.Profiles.AllIncluding(p => p.Account).FirstOrDefault(p => p.Account.Id == _user.User.Id);
            if (profile == null)
            {
                _uow.Profiles.Add(UserProfile.New(string.Empty, string.Empty, DateTime.Today, true, _user.User));
                _uow.Save();
            }

            return RedirectToAction<UserProfileController>(c => c.Index());
        }

        public ActionResult NewEducation(Guid profileId)
        {
            var vm = new EducationBindingModel()
            {
                ProfileId = profileId,
                StartDate = new MonthYear(Month.Jan, DateTime.Now.Year),
                EndDate = new MonthYear(Month.Jan, DateTime.Now.Year)
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult NewEducation(Guid profileId, EducationBindingModel form)
        {
            var profile = _uow.Profiles.FindById(profileId);
            profile.AddEducation(form.Specialization, form.ProgramDescription,
                                    form.EducationPlace, form.Duration, form.StartDate, form.EndDate);
            _uow.Save();

            return RedirectToAction<UserProfileController>(c => c.Index());
        }
        public ActionResult NewPublication(Guid profileId)
        {
            var vm = new PublicationBindingModel()
            {
                ProfileId = profileId,
                PublishedDate = DateTime.Today
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult NewPublication(Guid profileId, PublicationBindingModel form)
        {
            var profile = _uow.Profiles.FindById(profileId);
            profile.AddUserPublication(form.ISSN,
                                        form.Title, form.Brief,
                                        form.Authors, form.Publisher,
                                        form.PublishedDate);
            _uow.Save();

            return RedirectToAction<UserProfileController>(c => c.Index());
        }

        public ActionResult NewJob(Guid profileId)
        {
            var vm = new JobBindingModel()
            {
                ProfileId = profileId,
                FromDate = DateTime.Today
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult NewJob(Guid profileId, JobBindingModel form)
        {
            var profile = _uow.Profiles.FindById(profileId);
            profile.AddWorkExperience(form.Position, form.QuitReseason, form.Company, form.FromDate, form.ToDate);
            _uow.Save();

            return RedirectToAction<UserProfileController>(c => c.Index());
        }


        public ActionResult NewProject(Guid profileId)
        {
            var vm = new ProjectBindingModel()
            {
                ProfileId = profileId
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult NewProject(Guid profileId, ProjectBindingModel form)
        {
            var profile = _uow.Profiles.FindById(profileId);
            profile.AddProject(form.Name, form.Description, form.Role, form.TotalBudget, form.Duration, form.OtherCompany);
            _uow.Save();

            return RedirectToAction<UserProfileController>(c => c.Index());
        }

    }
}