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
            var vm = _uow.Documents.FilterBy(d => d.Container == null)
                            .OrderByDescending(d => d.LastUpdated).Project().To<DocumentViewModel>();

            return View(vm);
        }

        //
        // GET: /Cheetah/Document/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        public ActionResult FolderView(Guid Id)
        {
            var folder = _uow.Documents.AllIncluding(c => c.Children, c => c.Container).Where(d => d.Id == Id).FirstOrDefault();

            var vm = folder.Children.AsQueryable().OrderByDescending(d => d.LastUpdated).Project().To<DocumentViewModel>();

            ViewData["breadcrumb"] = string.Join(" > ", folder.GetHierachy().Select(i => i.Name));

            return View("Index", vm);
        }

        //
        // GET: /Cheetah/Document/Create
        public ActionResult AddFile()
        {
            ViewData["Folder"] = _uow.Documents.AllIncluding(d => d.CreatedBy).Where(d => d.IsFolder == true && d.CreatedBy.Username == User.Identity.Name).ToSelectList(i => i.Id.ToString(), i => i.Name.ToString(), string.Empty);

            return View();
        }

        //[Route("s/{securitycode}/{documentId}")]
        public ActionResult FileShare(Guid id)
        {
            var doc = _uow.Documents.FindById(id);
            return View("DocShare", AutoMapper.Mapper.Map<DocumentViewModel>(doc));
        }

        [HttpPost]
        public ActionResult FileShare(Guid id, DocShareBindingModel form)
        {
            var file = _uow.Documents.FindById(id);
            
            //file.AddShare(form.Permissions, )
            return View();
        }


        [Route("sh/{securitycode}/{documentId}")]
        public ActionResult FolderShare(Guid documentId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddFile(DocumentBindingModel form, HttpPostedFileBase file)
        {
            var path = @"C:\Users\Hà\Desktop\upload";

            // Check permission to download 

            var container = _uow.Documents.FindById(form.FolderId);
            var document = Doc.CreateFile(form.Name, form.Description, form.IsFolder, file != null ? path + file.FileName : path, container, _user.User);

            if (file != null)
            {
                file.SaveAs(path + file.FileName);
                document.ContentType = file.ContentType;
                document.ContentLength = file.ContentLength;
            }

            _uow.Documents.Add(document);
            _uow.Save();

            return RedirectToAction<DocumentController>(c => c.Index());
        }

        public ActionResult DownloadFile(Guid id)
        {
            var file = _uow.Documents.FindById(id);
            return File(file.Path, System.Net.Mime.MediaTypeNames.Application.Octet, file.Name);
        }

        private ActionResult File()
        {
            throw new NotImplementedException();
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
