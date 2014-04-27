using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSync.Models;

namespace DataSync.Controllers
{
    public class FieldsController : Controller
    {
        private oms_nsEntities db = new oms_nsEntities();

        //
        // GET: /Fields/

        public ActionResult Index(int ProgramId)
        {
            ViewBag.pId = ProgramId;
            return View(db.tbl_fields.Where(f=>f.F_PARENT == "0").ToList());
        }

        //
        // GET: /Fields/Details/5

        public ActionResult Details(string id = null)
        {
            tbl_fields tbl_fields = db.tbl_fields.Find(id);
            if (tbl_fields == null)
            {
                return HttpNotFound();
            }
            return View(tbl_fields);
        }

        //
        // GET: /Fields/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fields/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_fields tbl_fields)
        {
            if (ModelState.IsValid)
            {
                db.tbl_fields.Add(tbl_fields);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_fields);
        }

        //
        // GET: /Fields/Edit/5

        public ActionResult Edit(string id = null)
        {
            tbl_fields tbl_fields = db.tbl_fields.Find(id);
            if (tbl_fields == null)
            {
                return HttpNotFound();
            }
            return View(tbl_fields);
        }

        //
        // POST: /Fields/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_fields tbl_fields)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_fields).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_fields);
        }

        //
        // GET: /Fields/Delete/5

        public ActionResult Delete(string id = null)
        {
            tbl_fields tbl_fields = db.tbl_fields.Find(id);
            if (tbl_fields == null)
            {
                return HttpNotFound();
            }
            return View(tbl_fields);
        }

        //
        // POST: /Fields/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_fields tbl_fields = db.tbl_fields.Find(id);
            db.tbl_fields.Remove(tbl_fields);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}