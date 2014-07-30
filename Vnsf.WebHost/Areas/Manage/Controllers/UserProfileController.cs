using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;
using Microsoft.Web.Mvc;
using Vnsf.WebHost.Infrastructure.Alerts;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Entities;
using System.Threading.Tasks;
using Vnsf.WebHost.Areas.Manage.Models;
using Vnsf.WebHost.Infrastructure;
using Vnsf.Data;
using System.IO;
using Vnsf.Data.Entities.Registration;

namespace Vnsf.WebHost.Areas.Manage.Controllers
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
            var profile = _uow.UserAccounts.AllIncluding(u => u.Profile).First(u => u.Id == _user.User.Id).Profile;
            if (profile != null)
            {

            }
            return null;
        }

    }
}