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
    public class CategoryController : MvcBaseController
    {
        public CategoryController(IUnitOfWork uow)
            : base(uow)
        {

        }
        //
        // GET: /Manage/Category/
        public ActionResult Index()
        {
            var vm = _uow.Categories.All.Project().To<CategoryViewModel>();

            return View(vm);
        }

        //
        // GET: /Manage/Category/Details/5
        public ActionResult Details(Guid id)
        {
            var vm = _uow.Categories.AllIncluding(o => o.Classification)
                                    .Project().To<CategoryViewModel>()
                                    .FirstOrDefault(c => c.Id == id);

            return View(vm);
        }

        //
        // GET: /Manage/Category/Create
        public ActionResult Create()
        {
            var repo = _uow.ClassificationRepo.All.ToList();
            ViewData["Classifications"] = repo
                        .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);
            var vm = new CategoryBindingModel();
            return View(vm);
        }

        //
        // POST: /Manage/Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(CategoryBindingModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var classifcation = await _uow.ClassificationRepo.FindAsyncById(form.ClassificationId);
                    classifcation.Categories.Add(new Category(form.Name, form.Description));
                    await _uow.SaveAsync();
                }
                return RedirectToAction<CategoryController>(c => c.Index()).WithSuccess("Created");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            var vm = _uow.Categories.AllIncluding(o => o.Classification)
                                    .Project().To<CategoryBindingModel>()
                                    .FirstOrDefault(c => c.Id == id);

            ViewData["Classifications"] = _uow.ClassificationRepo.All
                                    .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(),
                                                    vm.ClassificationId.ToString());

            return View(vm);
        }

        //
        // POST: /Manage/Category/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, CategoryBindingModel form)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var item = await _uow.Categories.FindAsyncById(id);
                    item.Name = form.Name;
                    item.Description = form.Description;

                    var classification = await _uow.ClassificationRepo.FindAsyncById(form.ClassificationId);
                    item.Classification = classification;
                    await _uow.SaveAsync();
                }

                return RedirectToAction<CategoryController>(c => c.Index()).WithSuccess("Completed");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Category/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vm = _uow.Categories.AllIncluding(o => o.Classification)
                        .Project().To<CategoryViewModel>()
                        .FirstOrDefault(c => c.Id == id);

            return View(vm);
        }

        //
        // POST: /Manage/Category/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, FormCollection collection)
        {
            try
            {
                var item = await _uow.Categories.FindAsyncById(id);
                _uow.Categories.Remove(item);
                await _uow.SaveAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
