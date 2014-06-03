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
            var vm = _uow.Grants.AllIncluding(g => g.ClassificationSystem).Project().To<GrantViewModel>();

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
            ViewData["Issuers"] = _uow.Organizations.All.OfType<FundingAgency>()
                                   .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);
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
                    var issuer = _uow.Organizations.All.OfType<FundingAgency>().First(a => a.Id == form.IssuerId);
                    //var grant = AutoMapper.Mapper.Map<Grant>(form);

                    _uow.Grants.Add(new Grant
                    {
                        Id = Guid.NewGuid(),
                        Code = form.Code,
                        Name = form.Name,
                        Description = form.Description,
                        Total = form.Total,
                        MaxAward = form.MaxAward,
                        MaxDuration = form.MaxDuration,
                        Agency = issuer
                    });
                    await _uow.SaveAsync();
                }

                return RedirectToAction<GrantController>(c => c.Index()).WithSuccess("Created");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Grant/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = _uow.Grants.AllIncluding(g => g.Agency).First(g => g.Id == id);
            var vm = AutoMapper.Mapper.Map<GrantBindingModel>(item);

            ViewData["Issuers"] = _uow.Organizations.All.OfType<FundingAgency>()
           .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), item.Agency.ToString());


            return View(vm);
        }

        //
        // POST: /Manage/Grant/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, GrantBindingModel form)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var issuer = _uow.Organizations.All.OfType<FundingAgency>().First(a => a.Id == form.IssuerId);
                    var grant = await _uow.Grants.FindAsyncById(id);
                    grant.Code = form.Code;
                    grant.Name = form.Name;
                    grant.Description = form.Description;
                    grant.Objective = form.Objective;
                    grant.MaxAward = form.MaxAward;
                    grant.MaxDuration = form.MaxDuration;
                    grant.Total = form.Total;
                    grant.Agency = issuer;

                    await _uow.SaveAsync();
                }

                return RedirectToAction<GrantController>(c => c.Index()).WithSuccess("Updated");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Grant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Grant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
