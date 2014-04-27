using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class ClassificationController : MvcBaseController
    {
        public ClassificationController(IUnitOfWork uow)
            : base(uow)
        {

        }
        //
        // GET: /Admin/Classification/
        public ActionResult Index()
        {
            var vm = _uow.ClassificationRepo.All.ToList().Select(c => new ClassificationViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
            return View(vm);
        }

        //
        // GET: /Admin/Classification/Details/5
        public ActionResult Details(Guid id)
        {
            var vm = _uow.ClassificationRepo.All.ToList().Select(c => new ClassificationViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).FirstOrDefault(c => c.Id == id);
            return View(vm);
        }

        //
        // GET: /Admin/Classification/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Classification/Create
        [HttpPost]
        public ActionResult Create(Classification classification)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var cs = new Classification();
                    cs.Id = Guid.NewGuid();
                    cs.Name = classification.Name;
                    cs.Description = classification.Description;

                    _uow.ClassificationRepo.Add(cs);
                    _uow.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Classification/Edit/5
        public ActionResult Edit(Guid id)
        {
            var vm = _uow.ClassificationRepo.All.ToList().Select(c => new ClassificationViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).FirstOrDefault(c => c.Id == id);

            //var mvm = new ClassificationBindingModel(vm);
            return View();
        }

        //
        // POST: /Admin/Classification/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, ClassificationViewModel classification)
        {
            try
            {
                // TODO: Add update logic here
                var item = _uow.ClassificationRepo.All.FirstOrDefault(c => c.Id == id);

                item.Name = classification.Name;
                item.Description = classification.Description;
                _uow.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Classification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Classification/Delete/5
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

        public ActionResult Categories(Guid Id)
        {
            return View();
        }
    }
}
