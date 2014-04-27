using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class UserAccountController : MvcBaseController
    {
        public UserAccountController(IUnitOfWork uow)
            : base(uow)
        {

        }

        //
        // GET: /Admin/UserAccount/
        public ActionResult Index()
        {
            var vm = _uow.UserAccounts.All;

            return View(vm);
        }

        //
        // GET: /Admin/UserAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/UserAccount/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Admin/UserAccount/Create
        [HttpPost]
        public ActionResult Create(UserAccount userAccount)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var vm = UserAccount.Init(userAccount.Username, userAccount.HashedPassword, userAccount.Email);
                    _uow.UserAccounts.Add(vm);
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
        // GET: /Admin/UserAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/UserAccount/Edit/5
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

        //
        // GET: /Admin/UserAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/UserAccount/Delete/5
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
