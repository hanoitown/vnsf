using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Areas.Manage.Models;

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
                (p, g) => g.Select(c => new PostViewModel { Id = p.Id, Title = c.Title })
                           .DefaultIfEmpty(new PostViewModel { Id = p.Id, Title = p.Title }))
                .SelectMany(g => g);


            return View(vm);
        }

        // GET: Manage/Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manage/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Post/Create
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

        // GET: Manage/Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manage/Post/Edit/5
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

        // GET: Manage/Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manage/Post/Delete/5
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
