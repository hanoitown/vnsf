using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class GrantController : Controller
    {
        IInformationService grantsvc;
        private readonly IUserService _user;

        public GrantController(IInformationService grantSvc, IUserService user)
        {
            grantsvc = grantSvc;
            _user = user;
        }

        public GrantController()
        {

        } 
        //
        // GET: /Cheetah/Grant/
        public ActionResult Index()
        {
            var grants = grantsvc.GetAvailableGrants().ToList();
            var vm = grants.Select(g => new GrantViewModel(g));

            return View(vm);
        }

        //
        // GET: /Cheetah/Grant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cheetah/Grant/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cheetah/Grant/Create
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
        // GET: /Cheetah/Grant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cheetah/Grant/Edit/5
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
        // GET: /Cheetah/Grant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cheetah/Grant/Delete/5
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
