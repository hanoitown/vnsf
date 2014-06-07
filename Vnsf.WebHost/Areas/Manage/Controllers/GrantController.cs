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
    public class GrantController : MvcBaseController
    {
        public GrantController(IUnitOfWork uow)
            : base(uow)
        {

        }

        //
        // GET: /Manage/Grant/
        public ActionResult Index()
        {
            var vm = _uow.Grants.All.OrderByDescending(g => g.Created).Project().To<GrantViewModel>();

            return View(vm);
        }

        //
        // GET: /Manage/Grant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Manage/Grant/Create
        public ActionResult Create()
        {
            var vm = new GrantBindingModel();
            return View(vm);
        }

        //
        // POST: /Manage/Grant/Create
        [HttpPost]
        public async Task<ActionResult> Create(GrantBindingModel form)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //var issuer = _uow.Organizations.All.OfType<FundingAgency>().First(a => a.Id == form.IssuerId);
                    //var grant = AutoMapper.Mapper.Map<Grant>(form);
                    _uow.Grants.Add(Grant.NewGrant(form.Code, form.Name, form.Description, form.Objective, form.Scope, form.IsActive, form.Total));

                    await _uow.SaveAsync();
                }

                return RedirectToAction<GrantController>(c => c.Index()).WithSuccess("Created");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var item = await _uow.Grants.FindAsyncById(id);
            var vm = AutoMapper.Mapper.Map<GrantBindingModel>(item);

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, GrantBindingModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var grant = await _uow.Grants.FindAsyncById(id);

                    grant.Code = form.Code;
                    grant.Name = form.Name;
                    grant.Description = form.Description;
                    grant.Objective = form.Objective;
                    grant.Scope = form.Scope;
                    grant.IsActive = form.IsActive;
                    grant.Total = form.Total;

                    await _uow.SaveAsync();
                }

                return RedirectToAction<GrantController>(c => c.Index()).WithSuccess("Updated");
            }
            catch (Exception ex)
            {
                return RedirectToAction<GrantController>(c => c.Index()).WithError("Updated failed " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var grant = await _uow.Grants.FindAsyncById(id);
                _uow.Grants.Remove(grant);

                await _uow.SaveAsync();

                return RedirectToAction<GrantController>(c => c.Index()).WithSuccess("Deleted");
            }
            catch (Exception ex)
            {
                return RedirectToAction<GrantController>(c => c.Index()).WithError("Delete failed " + ex.Message);
            }
        }
    }
}
