﻿using Microsoft.AspNet.Identity;
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
using System.Diagnostics;
using Vnsf.Data;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    [Authorize]
    public class DocumentController : MvcBaseController
    {
        ICurrentUser _user;
        AppConfiguration _config;
        public DocumentController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
            _config = new AppConfiguration(AppSettings.Instance);
        }

        public ActionResult Index()
        {
            var vm = new DocumentsSelectionViewModel();
            if (Request.RequestContext.RouteData.Values["path"] == null)
                vm.Path = "/home/";
            else
                vm.Path = Request.RequestContext.RouteData.Values["path"].ToString();

            vm.Documents = _uow.Documents.AllIncluding(o => o.Owner).Where(d => d.Parent == null && d.Owner.Id == _user.User.Id).Select(doc => new SelectDocumentBindingModel
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Description = doc.Description
                }).ToList();
            Debug.WriteLine(Request.RequestContext.RouteData.Values["path"]);
            return View(vm);
        }

        public ActionResult Create(bool isFolder, string path)
        {
            //var path = Request.RequestContext.RouteData.Values["path"].ToString();
            var vm = new DocumentBindingModel(isFolder, path);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(DocumentBindingModel form, HttpPostedFileBase file)
        {

            var container = _uow.Documents.FilterBy(d => d.Path == form.Path).FirstOrDefault();
            var document = Doc.CreateFile(file.FileName, string.Empty, true, _config.BaseUrl, container, _user.User);

            if (file != null)
            {
                file.SaveAs(_config.BaseUrl + file.FileName);
                document.ContentType = file.ContentType;
                document.ContentLength = file.ContentLength;
            }

            _uow.Documents.Add(document);
            _uow.Save();

            return RedirectToAction<DocumentController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Index(DocumentsSelectionViewModel model)
        {
            var selectedIds = model.GetSelectedIds();

            var selectedDocs = _uow.Documents.FilterBy(d => selectedIds.Contains(d.Id));
            return View();
        }
        //
        // GET: /Cheetah/Document/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        public ActionResult FolderView(Guid Id)
        {
            var folder = _uow.Documents.AllIncluding(c => c.Children, c => c.Parent).Where(d => d.Id == Id).FirstOrDefault();

            //var vm = folder.Children.AsQueryable().OrderByDescending(d => d.LastUpdated).Project().To<DocumentViewModel>();

            var vm = new DocumentsSelectionViewModel();
            var docs = folder.Children.AsQueryable().OrderByDescending(d => d.IsFolder);
            foreach (var doc in docs)
            {
                vm.Documents.Add(new SelectDocumentBindingModel
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Description = doc.Description,
                    ContentType = doc.ContentType,
                    ContentLength = doc.ContentLength,
                    IsFolder = doc.IsFolder
                });
            }

            ViewData["folderId"] = Id;
            ViewData["breadcrumb"] = folder.GetHierachy().Select(c => new DocumentViewModel
            {
                Id = c.Id,
                Name = c.Name
            });
            return View("Index", vm);
        }

        //
        // GET: /Cheetah/Document/Create
        public ActionResult AddFile(Guid folderId)
        {
            //ViewData["Folder"] = _uow.Documents.AllIncluding(d => d.CreatedBy).Where(d => d.IsFolder == true && d.CreatedBy.Username == User.Identity.Name).ToSelectList(i => i.Id.ToString(), i => i.Name.ToString(), string.Empty);

            return View();
        }

        //[Route("s/{securitycode}/{documentId}")]
        [AllowAnonymous]
        public ActionResult FileShare(Guid id)
        {
            var doc = _uow.Documents.FindById(id);
            return View(AutoMapper.Mapper.Map<DocumentViewModel>(doc));
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
            var path = @"C:\Users\Hà\Desktop\upload\";

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

            return RedirectToAction<DocumentController>(c => c.FolderView(form.FolderId));
        }
        [AllowAnonymous]
        public ActionResult DownloadFile(Guid id)
        {
            var file = _uow.Documents.FindById(id);
            return File(file.Path, MimeMapping.GetMimeMapping(file.Name), file.Name);
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
                //var selectedDocs = _uow.Documents.FilterBy(d => selectedIds.Contains(d.Id));

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
