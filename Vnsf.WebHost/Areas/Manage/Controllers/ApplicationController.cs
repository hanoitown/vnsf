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
using Vnsf.WebHost.Areas.Cheetah.Models;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class ApplicationController : MvcBaseController
    {
        ICurrentUser _user;
        public ApplicationController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }

        public ActionResult Index()
        {
            var vm = _uow.Apps.AllIncluding(a => a.Opportunity, a => a.Applicant).Project().To<ApplicationManageViewModel>();
            return View(vm);
        }

        public ActionResult Delete(Guid id)
        {
            var vm = _uow.Apps.FindById(id);
            _uow.Apps.Remove(vm);
            _uow.Save();
            return RedirectToAction<ApplicationController>(c => c.Index());
        }

        public ActionResult View(Guid id)
        {
            var vm = AutoMapper.Mapper.Map<ApplicationManageViewModel>(_uow.Apps.FindById(id));

            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult AppDocs(Guid id)
        {
            var item = _uow.Apps.AllIncluding(d => d.Documents, d => d.Opportunity, d => d.Applicant).FirstOrDefault(a => a.Id == id && a.Applicant.Id == _user.User.Id);
            if (item == null)
                throw new ArgumentNullException();
            var doc = item.Documents;
            var form = _uow.AppForms.All.Where(f => f.Opportunity.Id == item.Opportunity.Id).ToList();

            // in order to join, need 2 lists first, queryable not support
            var vm = form.GroupJoin(doc, f => f.Id, d => d.Form.Id,
                    (p, c) => c
                    .Select(a => new AppDocumentViewModel { Id = a.Id, FormId = p.Id, FileName = a.FileName, FormName = p.Name, FormCode = p.Code })
                    .DefaultIfEmpty(new AppDocumentViewModel { FormId = p.Id, FileName = string.Empty, FormName = p.Name, FormCode = p.Code }))
                    .SelectMany(c => c).ToList();

            return PartialView("_AppDocs", vm);
        }

    }
}