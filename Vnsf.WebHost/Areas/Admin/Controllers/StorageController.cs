using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class StorageController : MvcBaseController
    {
        public StorageController(IUnitOfWork uow)
            : base(uow)
        {
        }

        public ActionResult Index()
        {
            _uow.Storages.Add(new Storage
                             {
                                 Id = Guid.NewGuid(),
                                 Name = "Storage"
                             });
            _uow.Save();
            var vm = _uow.Storages.All;
            return View(vm);
        }

        // GET: /Admin/Storage/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var storage = new Storage();
            //Storage storage = _uow.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // GET: /Admin/Storage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Storage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Name,Description,Created,LastUpdated")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                storage.Id = Guid.NewGuid();
                _uow.Storages.Add(storage);
                _uow.Save();
                return RedirectToAction("Index");
            }

            return View(storage);
        }

        // GET: /Admin/Storage/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var storage = new Storage();
            //Storage storage = _uow.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: /Admin/Storage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Name,Description,Created,LastUpdated")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(storage);
        }

        // GET: /Admin/Storage/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var storage = new Storage();
            //Storage storage = _uow.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: /Admin/Storage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var storage = new Storage();
            //Storage storage = _uow.Storages.Find(id);
            _uow.Storages.Remove(storage);
            _uow.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
