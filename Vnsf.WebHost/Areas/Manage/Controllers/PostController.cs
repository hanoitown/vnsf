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
    public class PostController : MvcBaseController
    {
        public PostController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public ActionResult Index()
        {
            var data = _uow.Posts.AllIncluding(p => p.Category);
            var locales = _uow.LocalPosts.AllIncluding(c => c.DestCulture).Where(c => c.DestCulture.Code == this.CurrentCulture);

            var vm = data.GroupJoin(locales,
                p => p.Id,
                c => c.Id,
                (p, g) => g.Select(c => new PostViewModel { Id = p.Id, Title = c.Title, PublishDate = p.PublishDate, CategoryName = p.Category.Name })
                           .DefaultIfEmpty(new PostViewModel { Id = p.Id, Title = p.Title, PublishDate = p.PublishDate, CategoryName = p.Category.Name }))
                .SelectMany(g => g);


            return View(vm);
        }


        public ActionResult Create()
        {
            var vm = new PostBindModel
            {
                PublishDate = DateTime.Today
            };
            ViewData["Categories"] = _uow.Categories.AllIncluding(c => c.Classification).Where(c => c.Classification.Name.Contains("Posts"))
                                            .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(PostBindModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = _uow.Categories.FindById(form.CategoryId);
                    _uow.Posts.Add(Post.New(form.Title, form.Abstract, form.Content, form.PublishDate, category));
                    _uow.Save();

                    return RedirectToAction<PostController>(p => p.Index()).WithSuccess("Created");
                }

                return RedirectToAction<PostController>(p => p.Index()).WithError("Invalid data");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var item = _uow.Posts.AllIncluding(p => p.Category).FirstOrDefault(p => p.Id == id);
            var vm = AutoMapper.Mapper.Map<PostBindModel>(item);

            ViewData["Categories"] = _uow.Categories.AllIncluding(c => c.Classification).Where(c => c.Classification.Name.Contains("Posts"))
                                            .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), item.Category.Id.ToString());

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, PostBindModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cat = _uow.Categories.FindById(form.CategoryId);
                    var post = _uow.Posts.FindById(form.Id);

                    post.Title = form.Title;
                    post.Abstract = form.Abstract;
                    post.Content = form.Content;
                    post.PublishDate = form.PublishDate;
                    post.Category = cat;

                    _uow.Save();

                    return RedirectToAction<PostController>(p => p.Index()).WithSuccess("Updated");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var item = _uow.Posts.FindById(id);
            _uow.Posts.Remove(item);
            _uow.Save();

            return View();
        }

    }
}
