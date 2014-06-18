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
using Vnsf.WebHost.Infrastructure;
using Vnsf.WebHost.Areas.Cheetah.Models;


namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class OpportunityController : MvcBaseController
    {
        ICurrentUser _user;
        public OpportunityController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }

        //
        // GET: /Cheetah/Opportunity/
        public ActionResult Index()
        {
            var vm = _uow.Opps.AllIncluding(o => o.Grant)
                            .Project().To<OppViewModel>();

            return View(vm);
        }

        public ActionResult RecentOpportunity()
        {
            var vm = _uow.Opps.AllIncluding(o => o.Grant)
                                .Where(o => DateTime.Compare(DateTime.Now, o.StartDate) < 30)
                                .Project().To<OppViewModel>();
            return View("Index", vm);
        }

        public ActionResult Details(Guid id)
        {
            var vm = _uow.Opps.AllIncluding(o => o.Grant, o=>o.Grant.Classification)
                                .Project().To<OppViewModel>()
                                .First(o => o.Id == id);

            
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Apply(Guid id)
        {
            var opportunity = _uow.Opps.FindById(id);
            if (opportunity == null)
                throw new InvalidOperationException();
            if (_user.User == null)
                throw new InvalidOperationException();

            var app = _uow.UserAccounts.AllIncluding(u => u.Applications).First(u => u.Id == _user.User.Id)
                                        .CreateApplication(opportunity);
            _uow.Save();

            return RedirectToAction<ApplicationController>(a => a.Details(app.Id));
        }

    }
}
