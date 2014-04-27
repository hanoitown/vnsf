using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Infrastructure.Alerts;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class DocumentController : MvcBaseController
    {
        public DocumentController(IUnitOfWork uow)
            : base(uow)
        {

        }
        //
        // GET: /Admin/Document/
        public ActionResult Index()
        {
            var storage = _uow.Storages.All.FirstOrDefault(s => s.Name == "Storage");
            _uow.Documents.Add(new Doc
                               {
                                   Id = Guid.NewGuid(),
                                   Name = "Docs",
                                   Storage = storage
                               });
            _uow.Save();
            var vm = _uow.Documents.AllIncluding(d => d.Storage).Project().To<DocumentViewModel>();
            return View(vm);
        }

        //
        // GET: /Admin/Document/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Document/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Document/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index").WithSuccess("Complete");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Document/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Document/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction<DocumentController>(c => c.Index());
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Document/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Document/Delete/5
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
