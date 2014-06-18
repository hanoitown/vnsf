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

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class OpportunityController : MvcBaseController
    {

        public OpportunityController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public ActionResult Index()
        {
            var vm = _uow.Opps.AllIncluding(o => o.Grant).Project().To<OppViewModel>();

            return View(vm);
        }

        public ActionResult Details(Guid id)
        {
            var item = _uow.Opps.AllIncluding(g => g.Grant).First(g => g.Id == id);
            var vm = AutoMapper.Mapper.Map<OppViewModel>(item);

            return View(vm);
        }

        public ActionResult Create()
        {
            ViewData["Grants"] = _uow.Grants.All
                       .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);

            var vm = new OppBindingModel();
            vm.StartDate = vm.Deadline = DateTime.Now;

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OppBindingModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var grant = _uow.Grants.All.First(a => a.Id == form.GrantId);
                    _uow.Opps.Add(Opportunity.NewOpportunity(grant, form.Name, form.Description, form.NumberOfAward, form.TotalAward, form.StartDate, form.Deadline));

                    await _uow.SaveAsync();
                }

                return RedirectToAction<OpportunityController>(c => c.Index()).WithSuccess("Created");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Opportunity/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = _uow.Opps.AllIncluding(g => g.Grant).First(g => g.Id == id);
            var vm = AutoMapper.Mapper.Map<OppBindingModel>(item);

            ViewData["Grants"] = _uow.Grants.All
                    .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), item.Grant.Id.ToString());

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, OppBindingModel form)
        {
            try
            {
                // TODO: Require grant existed
                if (ModelState.IsValid)
                {
                    var grant = _uow.Grants.FindById(form.GrantId);
                    var opp = await _uow.Opps.FindAsyncById(id);

                    opp.Name = form.Name;
                    opp.Description = form.Description;
                    opp.StartDate = form.StartDate;
                    opp.Deadline = form.Deadline;
                    opp.NumberOfAward = form.NumberOfAward;
                    opp.TotalAward = form.TotalAward;
                    opp.Grant = grant;
                    await _uow.SaveAsync();

                    return RedirectToAction<OpportunityController>(c => c.Index()).WithSuccess("Updated");
                }

                return RedirectToAction<OpportunityController>(c => c.Index()).WithError("Update failed");

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var item = await _uow.Opps.FindAsyncById(id);
                _uow.Opps.Remove(item);

                await _uow.SaveAsync();

                return RedirectToAction<OpportunityController>(c => c.Index()).WithSuccess("Deleted");
            }
            catch (Exception ex)
            {
                return RedirectToAction<OpportunityController>(c => c.Index()).WithError("Delete failed " + ex.Message);
            }
        }

    }
}
