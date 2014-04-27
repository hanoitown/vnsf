using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;
using Microsoft.Web.Mvc;
using Vnsf.WebHost.Infrastructure.Alerts;
using Vnsf.Data.Entities;
using System.Threading.Tasks;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class CultureController : MvcBaseController
    {
        public CultureController(IUnitOfWork uow)
            : base(uow)
        {

        }

        //
        // GET: /Manage/Culture/
        public ActionResult Index()
        {
            var vm = _uow.Cultures.All.Project().To<LocalizedCultureViewModel>();
            return View(vm);
        }

        //
        // GET: /Manage/Culture/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Manage/Culture/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manage/Culture/Create
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
        // GET: /Manage/Culture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Culture/Edit/5
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
        // GET: /Manage/Culture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Culture/Delete/5
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
