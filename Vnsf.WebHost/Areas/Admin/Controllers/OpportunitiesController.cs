using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Thinktecture.IdentityModel;
using Vnsf.Data.Entities;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class OpportunitiesController : Controller
    {
        IInformationService _svc;
        public OpportunitiesController(IInformationService infoSvc)
        {
            _svc = infoSvc;
        }

        //
        // GET: /Admin/Opportunities/
        public ActionResult Index()
        {
            var vm = _svc.GetAvailableOpportunities().Select(o => new OpportunityViewModel(o));
            return View(vm);
        }

        //
        // GET: /Admin/Opportunities/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        //
        // GET: /Admin/Opportunities/Create
        public ActionResult Create()
        {
            var grants = _svc.GetAvailableGrants();
            var classifications = _svc.GetClassifications();

            var vm = new OpportunityBindingModel(new Opportunity(), grants, classifications);
            return View(vm);
        }

        //
        // POST: /Admin/Opportunities/Create
        [HttpPost]
        public ActionResult Create(Opportunity opportunity)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                    _svc.CreateOpportunity(opportunity);

                return RedirectToAction("Index");
            }
            catch
            {
                var grants = _svc.GetAvailableGrants();
                var classifications = _svc.GetClassifications();

                var vm = new OpportunityBindingModel(opportunity, grants, classifications);
                return View(vm);
            }
        }

        //
        // GET: /Admin/Opportunities/Edit/5
        public ActionResult Edit(Guid id)
        {
            var grants = _svc.GetAvailableGrants();
            var opportunity = _svc.GetOpportunityById(id);
            var classifications = _svc.GetClassifications();

            var vm = new OpportunityBindingModel(opportunity, grants, classifications);
            return View(vm);

        }

        //
        // POST: /Admin/Opportunities/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Opportunity opportunity)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                    _svc.PutOpportunityById(id, opportunity);
                return RedirectToAction("Index");
            }
            catch
            {
                var grants = _svc.GetAvailableGrants();
                var classifications = _svc.GetClassifications();

                var vm = new OpportunityBindingModel(opportunity, grants, classifications);
                return View(vm);
            }
        }

        //
        // GET: /Admin/Opportunities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Opportunities/Delete/5
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
