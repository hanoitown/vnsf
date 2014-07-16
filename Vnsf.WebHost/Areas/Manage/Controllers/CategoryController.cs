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
using Vnsf.WebHost.Areas.Manage.Models;
using System.Text;

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
            var vm = _uow.Categories.AllIncluding(c => c.Parent).Where(c => c.Parent == null)
                            .Project().To<CategoryViewModel>().ToList();

            var list = new List<CategoryViewModel>();
            foreach (var item in vm)
            {
                list.Add(AutoMapper.Mapper.Map<CategoryViewModel>(item));
                if (item.Children != null)
                {
                    BuildChildNode(item);
                }
            }

            return View(list);
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


        public ActionResult AddChild(Guid parentId, Guid classId)
        {
            var vm = new CategoryBindingModel()
            {
                ParentId = parentId,
                ClassificationId = classId
            };


            var categories = _uow.Categories.AllIncluding(c => c.Parent).Where(c => c.Parent == null)
                        .Project().To<CategoryViewModel>().ToList();

            categories.ForEach(n => BuildChildNode(n));

            //foreach (var item in categories)
            //    BuildChildNode(item);

            var list = new List<SelectListItem>();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Selected = item.Id == parentId
                });
                ToSelectList(item, list);
            }

            ViewData["Categories"] = list;


            return View("Create", vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddChild(CategoryBindingModel form)
        {
            return await Create(form);
        }

        public ActionResult AddRoot(Guid classId)
        {
            var vm = new CategoryBindingModel()
            {
                ClassificationId = classId
            };

            return View("Create", vm);

        }

        [HttpPost]
        public async Task<ActionResult> AddRoot(CategoryBindingModel form)
        {
            return await Create(form);
        }

        //
        // GET: /Manage/Category/Create
        public ActionResult Create()
        {
            var repo = _uow.ClassificationRepo.All.ToList();

            ViewData["Classifications"] = repo
                        .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);

            var categories = _uow.Categories.AllIncluding(c => c.Parent).Where(c => c.Parent == null)
                                    .Project().To<CategoryViewModel>().ToList();
            var list = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                BuildChildNode(item);
                list.Add(AutoMapper.Mapper.Map<CategoryViewModel>(item));
            }

            var list2 = new List<SelectListItem>();
            foreach (var item in categories)
            {
                list2.Add(new SelectListItem { Text = item.Name });
                ToSelectList(item, list2);
            }

            ViewData["Categories"] = list2; //list.ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);

            var vm = new CategoryBindingModel();
            return View(vm);
        }

        private void ToSelectList(CategoryViewModel cat, List<SelectListItem> list)
        {
            if (cat.Children != null)
            {
                foreach (var item in cat.Children)
                {
                    list.Add(new SelectListItem() { 
                        Value = item.Id.ToString(),
                        Text = Prefix(2*item.Depth) + item.Name
                    });
                    ToSelectList(item, list);

                }
            }
        }

        private string Prefix(int count)
        {
            if (count == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("&nbsp;");
            }
            return Server.HtmlDecode(sb.ToString());
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


        [HttpPost]
        public async Task<ActionResult> Create(CategoryBindingModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var classifcation = await _uow.ClassificationRepo.FindAsyncById(form.ClassificationId);
                    var parent = _uow.Categories.FindById(form.ParentId);

                    classifcation.Categories.Add(Category.Create(form.Name, form.Description, 1, parent != null ? parent.Depth + 1 : 0, classifcation, parent));

                    await _uow.SaveAsync();
                }
                return RedirectToAction<ClassificationController>(c => c.Details(form.ClassificationId)).WithSuccess("Created");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var vm = AutoMapper.Mapper.Map<CategoryBindingModel>(
                        _uow.Categories.AllIncluding(c => c.Classification).FirstOrDefault(c => c.Id == id));

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, CategoryBindingModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await _uow.Categories.FindAsyncById(id);
                    item.Name = form.Name;
                    item.Description = form.Description;
                    await _uow.SaveAsync();
                }
                return RedirectToAction<ClassificationController>(c => c.Details(form.ClassificationId))
                                        .WithSuccess("Completed");
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
