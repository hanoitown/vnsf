using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.Service.Implementation;
using Vnsf.WebHost.Areas.Cheetah.Models;
using Vnsf.WebHost.Base;
using AutoMapper.QueryableExtensions;
using Vnsf.WebHost.Models;
using Vnsf.WebHost.Models.Document;
using Vnsf.WebHost.Infrastructure;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    [Authorize]
    public class DocumentController : MvcBaseController
    {
        ICurrentUser _user;

        public DocumentController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
        }
        public ActionResult Index()
        {
            var vm = _uow.Documents.All.OrderByDescending(d => d.LastUpdated).Project().To<DocumentViewModel>();

            return View(vm);
        }

        //
        // GET: /Cheetah/Document/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cheetah/Document/Create
        public ActionResult AddFile()
        {
            ViewData["Folder"] = _uow.Documents.AllIncluding(d => d.CreatedBy).Where(d => d.IsFolder == true && d.CreatedBy.Username == User.Identity.Name).ToSelectList(i => i.Id.ToString(), i => i.Name.ToString(), string.Empty);
            return View();
        }
        [HttpPost]
        public ActionResult AddFile(DocumentBindingModel form, HttpPostedFileBase file)
        {
            string path = @"C:\Users\Nguyen\Desktop\css\";

            if (file != null)
                file.SaveAs(path + file.FileName);
            var container = _uow.Documents.FindById(form.FolderId);
            var document = Doc.Create(form.Name, form.Description, file.ContentType, file.ContentLength, form.IsFolder, file != null ? path + file.FileName : path, container, _user.User);
            _uow.Documents.Add(document);
            _uow.Save();

            return RedirectToAction<DocumentController>(c => c.Index());
        }


        //
        // POST: /Cheetah/Document/Create
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

        //
        // GET: /Cheetah/Document/Edit/5
        public ActionResult Edit(Guid id)
        {
            var vm = _uow.Documents.FindById(id);
            _uow.Documents.Remove(vm);
            _uow.Save();

            return RedirectToAction("Index");
        }

        //
        // POST: /Cheetah/Document/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FolderViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                var vm = _uow.Documents.FindById(id);
                _uow.Documents.Remove(vm);
                _uow.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cheetah/Document/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vm = _uow.Documents.FindById(id);
            _uow.Documents.Remove(vm);
            _uow.Save();

            return RedirectToAction("Index");
        }

        //
        // POST: /Cheetah/Document/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
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
        [ChildActionOnly]
        public ActionResult UploadSingleDoc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadSingleDoc(FormCollection form)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CreateFolder()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateFolder(FolderCreateModel form)
        {
            try
            {

                return RedirectToAction<DocumentController>(c => c.Index());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
