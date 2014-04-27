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
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        IInformationService _svc;
        public CategoriesController(IInformationService infoSvc)
        {
            _svc = infoSvc;
        }

        // GET: /Admin/Categories/
        //public ActionResult Index()
        //{
        //    var classifications = _svc.GetClassifications();
        //    var categories = new List<Category>(); // _svc.getCategories;
        //    var vm = new CategoryViewModel(classifications, categories);
        //    return View(vm);
        //}

        public ActionResult Index(Guid? classificationId)
        {
            var classifications = _svc.GetClassifications();
            var categories = new List<Category>();
            //if (classificationId != null)
            //{
            //    var cls = _svc.GetClassificationById(classificationId ?? Guid.Empty);
            //    categories = cls.Categories.ToList();
            //}

            var vm = new CategoryViewModel();
            return View(vm);
        }

        // GET: /Admin/Categories/Details/5
        public ActionResult Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Category category = db.Categories.Find(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: /Admin/Categories/Create
        public ActionResult Create()
        {
            //var classification = _svc.GetClassifications();
            //var vm = new CategoryBindingModel(new Category(), classification);

            return View();
        }

        // POST: /Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description, ClassificationId")] Category category)
        {
            if (ModelState.IsValid)
            {
               //_svc.AddCategoryToClassifcation(category.ClassificationId, category);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: /Admin/Categories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Category category = db.Categories.Find(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: /Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Created,LastUpdated")] Category category)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(category).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View();
        }

        // GET: /Admin/Categories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Category category = db.Categories.Find(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: /Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //Category category = db.Categories.Find(id);
            //db.Categories.Remove(category);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
