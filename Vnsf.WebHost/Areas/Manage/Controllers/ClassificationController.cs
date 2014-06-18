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
using Microsoft.Web.Mvc;
using Vnsf.Resource.WebHost.Manage.Controllers.Classification;
using Vnsf.WebHost.Areas.Manage.Models;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class ClassificationController : MvcBaseController
    {
        public ClassificationController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public ActionResult Index()
        {
            var vm = _uow.Classifications.All.Project().To<ClassificationViewModel>();

            return View(vm);
        }

        public ActionResult Details(Guid id)
        {
            var vm = _uow.Classifications.AllIncluding(c => c.Categories).Where(c => c.Id == id)
                            .Project().To<ClassificationViewModel>().FirstOrDefault();

            var list = new List<CategoryViewModel>();

            foreach (var item in _uow.Categories.All.Where(c => c.Classification.Id == id && c.Parent == null).Project().To<CategoryViewModel>().ToList())
            {
                BuildChildNode(item);
                list.Add(AutoMapper.Mapper.Map<CategoryViewModel>(item));
            }

            vm.Categories = list;
            return View(vm);
        }

        private void BuildChildNode(CategoryViewModel cat)
        {
            if (cat != null)
            {
                var children = _uow.Categories.AllIncluding(c => c.Children).Where(c => c.Parent.Id == cat.Id)
                                        .Project().To<CategoryViewModel>().ToList();
                if (children != null)
                {
                    foreach (var child in children)
                    {
                        BuildChildNode(child);
                        cat.Children.Add(child);
                    }
                }
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassificationBindingModel classification)
        {
            try
            {
                _uow.ClassificationRepo.Add(new Classification
                                            {
                                                Id = Guid.NewGuid(),
                                                Name = classification.Name,
                                                Description = classification.Description,
                                            });
                _uow.Save();
                return RedirectToAction<ClassificationController>(c => c.Index()).WithSuccess("Completed");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Classification/Edit/5
        public ActionResult Edit(Guid id)
        {
            var vm = _uow.ClassificationRepo.FilterBy(c => c.Id == id)
                            .Project().To<ClassificationBindingModel>().FirstOrDefault();
            return View(vm);
        }

        //
        // POST: /Manage/Classification/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, ClassificationBindingModel classification)
        {
            try
            {
                var item = _uow.ClassificationRepo.FindById(id);
                item.Name = classification.Name;
                item.Description = classification.Description;
                _uow.Save();

                return RedirectToAction<ClassificationController>(c => c.Index())
                            .WithSuccess(Update.UpdateSuccess);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Classification/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vm = _uow.ClassificationRepo.FilterBy(c => c.Id == id)
                .Project().To<ClassificationViewModel>().FirstOrDefault();

            return View(vm);
        }

        //
        // POST: /Manage/Classification/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                var item = _uow.ClassificationRepo.FindById(id);
                _uow.ClassificationRepo.Remove(item);
                _uow.Save();

                return RedirectToAction<ClassificationController>(c => c.Index()).WithSuccess("Deleted");
            }
            catch (Exception ex)
            {
                return RedirectToAction<ClassificationController>(c => c.Index()).WithError(ex.Message);
            }
        }
    }
}
