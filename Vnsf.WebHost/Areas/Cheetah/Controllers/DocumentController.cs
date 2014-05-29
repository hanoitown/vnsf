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
using System.Diagnostics;
using Vnsf.Data;
using System.IO;

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

        private const string _home = "home";

        public ActionResult Index()
        {
            return RedirectToAction<DocumentController>(d => d.Browse(_home));
        }

        public ActionResult Browse(string location)
        {
            // lookup data in the system to collect physical entry
            var vm = new DocumentsSelectionViewModel();

            if (string.IsNullOrEmpty(location) || location.Equals(_home))
            {
                vm.CurrLocation = _home;
                // parent is null
                vm.Documents = _uow.Documents.AllIncluding(o => o.Owner).Where(d => d.Parent == null && d.Owner.Id == _user.User.Id).OrderByDescending(o => o.IsFolder).ThenBy(o => o.Name).Project().To<SelectDocumentBindingModel>();
            }
            else
            {
                vm.CurrLocation = Request.RequestContext.RouteData.Values["location"].ToString();
                vm.Documents = _uow.Documents.AllIncluding(o => o.Owner).Where(d => d.Location == location && d.Owner.Id == _user.User.Id).OrderByDescending(o => o.IsFolder).ThenBy(o => o.Name).Project().To<SelectDocumentBindingModel>();
            }

            //var _name = location.Substring(location.LastIndexOf('/') + 1);
            //var _location = location.Substring(0, location.LastIndexOf('/') + 1);

            //var items = new List<BreadItemViewModel>();
            //var current = _uow.Documents.FilterBy(d => d.Location == _location && d.Name == _name).FirstOrDefault();
            //ViewData["breadcums"] = current.GetHierachy().Select(d => new FolderViewModel
            //{
            //    Name = d.Name,
            //    Location = d.Location
            //});

            return View(vm);
        }

        public ActionResult Up(string location)
        {
            return RedirectToAction<DocumentController>(d => d.Browse(location));

        }

        [HttpPost]
        public async Task<ActionResult> Browse(DocumentsSelectionViewModel model)
        {
            var selectedIds = model.GetSelectedIds();
            foreach (var id in selectedIds)
            {
                var doc = await _uow.Documents.FindAsyncById(id);
                if (!doc.IsFolder)
                {
                    System.IO.File.Delete(doc.Path);
                    _uow.Documents.Remove(doc);
                    await _uow.SaveAsync();
                }
                else
                    await DeleteFolder(id);
            }
            return RedirectToAction<DocumentController>(d => d.Browse(_home));
        }

        public async Task DeleteFolder(Guid id)
        {
            var folder = await _uow.Documents.FindAsyncById(id);
            var children = _uow.Documents.FilterBy(f => f.Parent.Id == id).ToList();
            foreach (var child in children)
            {
                if (child.IsFolder)
                    await DeleteFolder(child.Id);
                else
                {
                    System.IO.File.Delete(child.Path);
                    _uow.Documents.Remove(child);
                    await _uow.SaveAsync();
                }
            }
            Directory.Delete(folder.Path);
            _uow.Documents.Remove(folder);
            await _uow.SaveAsync();
        }


        public ActionResult Create(string location)
        {
            var vm = new FolderBindingModel(location);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(FolderBindingModel form)
        {
            // find the parrent folder base on logical location

            var _name = form.Location.Substring(form.Location.LastIndexOf('/') + 1);
            var _location = form.Location.LastIndexOf('/') >= 0 ? form.Location.Substring(0, form.Location.LastIndexOf('/')) : string.Empty;

            var container = _uow.Documents.FilterBy(d => d.Location == _location && d.Name == _name).FirstOrDefault();

            // create child directory within the Path of the container
            string path = container == null ?
                            string.Format("{0}/{1}/{2}", Server.MapPath(_config.BaseUrl), _user.User.Email, form.Name) :
                            string.Format("{0}/{1}", container.Path, form.Name);
            var dir = Directory.CreateDirectory(path);


            if (Directory.Exists(dir.FullName))
            {
                //register with the system
                var document = Doc.CreateFile(form.Name, string.Empty, true, dir.FullName, container, _user.User);
                document.Location = container == null ? form.Location : string.Format("{0}/{1}", container.Location, container.Name);

                _uow.Documents.Add(document);
                _uow.Save();
                return RedirectToAction<DocumentController>(c => c.Browse(document.Location));
            }

            return RedirectToAction<DocumentController>(c => c.Browse(_home));

        }

        public ActionResult Upload(string location)
        {
            var vm = new FileUploadBindingModel(location);
            return View(vm);

        }
        [HttpPost]
        public ActionResult Upload(FileUploadBindingModel form, HttpPostedFileBase file)
        {
            var _name = form.Location.Substring(form.Location.LastIndexOf('/') + 1);
            var _location = form.Location.LastIndexOf('/') >= 0 ? form.Location.Substring(0, form.Location.LastIndexOf('/')) : string.Empty;

            var container = _uow.Documents.FilterBy(d => d.Location == _location && d.Name == _name).FirstOrDefault();

            string path = container == null ?
                            string.Format("{0}/{1}/{2}", Server.MapPath(_config.BaseUrl), _user.User.Email, file.FileName) :
                            string.Format("{0}/{1}", container.Path, file.FileName);
            // physical
            if (file != null)
                file.SaveAs(path);

            // logical
            var document = Doc.CreateFile(string.IsNullOrEmpty(form.Name) ? file.FileName : form.Name, string.Empty, false,
                                    new FileInfo(path).FullName, container, _user.User);
            document.ContentLength = file.ContentLength;
            document.ContentType = MimeMapping.GetMimeMapping(file.FileName);
            document.Location = form.Location;

            _uow.Documents.Add(document);
            _uow.Save();

            return RedirectToAction<DocumentController>(c => c.Browse(document.Location));
        }


        [AllowAnonymous]
        public ActionResult DownloadFile(Guid id)
        {
            var file = _uow.Documents.FindById(id);
            return File(file.Path, MimeMapping.GetMimeMapping(file.Name), file.Name);
        }


    }
}
