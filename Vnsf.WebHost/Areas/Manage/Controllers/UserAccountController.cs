using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Microsoft.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Vnsf.WebHost.Models;
using Vnsf.Data.Entities.Account;
using System.Threading.Tasks;
using Vnsf.WebHost.Infrastructure.Alerts;
using Vnsf.Resource.WebHost.Manage.Controllers.UserAccount;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class UserAccountController : MvcBaseController
    {
        public UserAccountController(IUnitOfWork uow)
            : base(uow)
        {

        }

        //
        // GET: /Manage/UserAccount/
        public ActionResult Index()
        {
            var vm = _uow.UserAccounts.All.Project().To<UserAccountViewModel>();

            return View(vm);
        }

        //
        // GET: /Manage/UserAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Manage/UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manage/UserAccount/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserAccountBindingModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = UserAccount.Init(form.Username, form.HashedPassword, form.Email);
                    _uow.UserAccounts.Add(account);
                    await _uow.SaveAsync();
                }

                return RedirectToAction<UserAccountController>(a => a.Index()).WithSuccess(CreateUser.CreateSuccess);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/UserAccount/Edit/5
        public ActionResult Edit(Guid id)
        {
            var vm = _uow.UserAccounts.All.Project().To<UserAccountBindingModel>().FirstOrDefault(c => c.Id == id);

            return View(vm);
        }

        //
        // POST: /Manage/UserAccount/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, UserAccountBindingModel form)
        {
            try
            {
                var item = await _uow.UserAccounts.FindAsyncById(id);
                item.UpdateUser(form.Username, form.Email);
                await _uow.SaveAsync();

                return RedirectToAction<UserAccountController>(c => c.Index()).WithSuccess(CreateUser.CreateSuccess);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/UserAccount/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vm = _uow.UserAccounts.All.Project().To<UserAccountViewModel>().FirstOrDefault(c => c.Id == id);
            return View(vm);
        }

        //
        // POST: /Manage/UserAccount/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, FormCollection collection)
        {
            try
            {
                var account = await _uow.UserAccounts.FindAsyncById(id);
                _uow.UserAccounts.Remove(account);
                await _uow.SaveAsync();

                return RedirectToAction<UserAccountController>(c => c.Index()).WithSuccess(CreateUser.CreateSuccess);
            }
            catch
            {
                return View();
            }
        }
    }
}
