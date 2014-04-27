using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vnsf.Data.Entities;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class GrantsController : Controller
    {
        IInformationService _svc;
        public GrantsController(IInformationService service)
        {
            _svc = service;
        }
        //
        // GET: /Admin/Grants/
        public ActionResult Index()
        {
            var vm = _svc.GetAvailableGrants().Select(g => new GrantViewModel
            {
                Id = g.Id,
                Code = g.Code,
                Name = g.Name,
                Description = g.Description,
                Objective = g.Objective,
                MaxAward = g.MaxAward,
                MaxDuration = g.MaxDuration,
                Total = g.Total,
                LastUpdated = g.LastUpdated
            });

            return View(vm);
        }

        //
        // GET: /Admin/Grants/Details/5
        public ActionResult Details(Guid id)
        {
            var grant = _svc.GetGrantDetailById(id);
            var vm = new GrantViewModel(grant);
            return View(vm);
        }

        //
        // GET: /Admin/Grants/Create
        public ActionResult Create()
        {
            var agencies = _svc.GetAllOrganizations();
            var grant = new Grant();

            var vm = new GrantBindingModel(grant, agencies);
            return View(vm);
        }

        //
        // POST: /Admin/Grants/Create
        [HttpPost]
        public ActionResult Create(Grant grant)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                    _svc.CreateGrant(grant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Grants/Edit/5
        public ActionResult Edit(Guid id)
        {
            var grant = _svc.GetGrantDetailById(id);
            var agencies = _svc.GetAllOrganizations();

            var vm = new GrantBindingModel(grant, agencies);
            return View(vm);
        }

        //
        // POST: /Admin/Grants/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Grant grant)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _svc.PutGrantById(id, grant);
                }
                var agencies = _svc.GetAllOrganizations();
                var vm = new GrantBindingModel(grant, agencies);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Grants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Grants/Delete/5
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


        public ActionResult CreateOpportunity(Guid grantId)
        {
            ViewBag.grantId = grantId.ToString();
            return View();
        }

        [HttpPost]

        public ActionResult CreateOpportunity(Guid grantId, Opportunity opportunity)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //opp.GrantId = grantId;
                    _svc.AddOpportunityToGrand(grantId, opportunity);
                }

                return RedirectToAction("Details", "Grants", new { Id = grantId });
            }
            catch
            {
                return View();
            }

        }
    }
}
