using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Infrastructure.Alerts;
using AutoMapper.QueryableExtensions;
using Vnsf.WebHost.Infrastructure.Alerts;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class AgencyController : MvcBaseController
    {
        public AgencyController(IUnitOfWork uow)
            : base(uow)
        {

        }

        //
        // GET: /Manage/Agency/
        public ActionResult Index()
        {
            var vm = _uow.Organizations.All.OfType<FundingAgency>().Project().To<AgencyViewModel>();

            return View(vm);
        }

        //
        // GET: /Manage/Agency/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Manage/Agency/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manage/Agency/Create
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
        // GET: /Manage/Agency/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Agency/Edit/5
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
        // GET: /Manage/Agency/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Agency/Delete/5
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
