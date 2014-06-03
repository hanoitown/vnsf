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
            var vm = _uow.OpportunitiesRepo.AllIncluding(o => o.Grant)
                            .Project().To<OppViewModel>();

            return View(vm);
        }

        public async Task<ActionResult> Apply(Guid id)
        {
            var opportunity = await _uow.OpportunitiesRepo.FindAsyncById(id);
            var app = _user.User.ApplyForGrant(opportunity);
            await _uow.SaveAsync();

            return RedirectToAction<ApplicationController>(a => a.Detail(app.Id));
        }

    }
}
