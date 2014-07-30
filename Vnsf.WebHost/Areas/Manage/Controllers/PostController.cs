using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class PostController : MvcBaseController
    {
        public PostController(IUnitOfWork uow)
            : base(uow)
        {

        }
        // GET: Manage/Post
        public ActionResult Index()
        {
            return View();
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
