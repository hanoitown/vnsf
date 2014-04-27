using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class OpportunityController : Controller
    {
        IInformationService _svc;
        public OpportunityController(IInformationService infoSvc)
        {
            _svc = infoSvc;
        }
        public OpportunityController()
        {

        }
        //
        // GET: /Cheetah/Opportunity/
        public ActionResult Index()
        {
            var vm = _svc.GetAvailableOpportunities().Select(o => new OpportunityViewModel(o));
            return View(vm);
        }

        //
        // GET: /Cheetah/Opportunity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cheetah/Opportunity/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cheetah/Opportunity/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cheetah/Opportunity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cheetah/Opportunity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cheetah/Opportunity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cheetah/Opportunity/Delete/5
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
