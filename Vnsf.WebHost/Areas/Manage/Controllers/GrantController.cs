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
using Vnsf.WebHost.Infrastructure.Alerts;

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
            return View();
        }

        //
        // POST: /Manage/Grant/Create
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
        // GET: /Manage/Grant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Grant/Edit/5
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
