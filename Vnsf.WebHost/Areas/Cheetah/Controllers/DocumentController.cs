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
using Vnsf.WebHost.Areas.Cheetah.Models;
using Vnsf.WebHost.Base;
using AutoMapper.QueryableExtensions;
using Vnsf.WebHost.Models;
using Vnsf.WebHost.Models.Document;
using Vnsf.WebHost.Infrastructure;
using System.Diagnostics;
using Vnsf.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text;

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
                vm.Documents = new List<DocumentViewModel>();
                var docs = _uow.Documents.AllIncluding(o => o.Owner).Where(d => d.Parent == null && d.Owner.Id == _user.User.Id).OrderByDescending(o => o.IsFolder).ThenBy(o => o.Name);

                foreach (var item in docs)
                {
                    vm.Documents.Add(AutoMapper.Mapper.Map<Doc, DocumentViewModel>(item));
                }
            }
            else
            {
                vm.CurrLocation = Request.RequestContext.RouteData.Values["location"].ToString();
                vm.Documents = new List<DocumentViewModel>();
                var docs = _uow.Documents.AllIncluding(o => o.Owner).Where(d => d.Location == location && d.Owner.Id == _user.User.Id).OrderByDescending(o => o.IsFolder).ThenBy(o => o.Name);

                foreach (var item in docs)
                {
                    vm.Documents.Add(AutoMapper.Mapper.Map<Doc, DocumentViewModel>(item));
                }
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
            //var selectedIds = model.GetSelectedIds();
            //var files = new List<string>();
            //foreach (var id in selectedIds)
            //{
            //    var doc = await _uow.Documents.FindAsyncById(id);
            //    files.Add(doc.Path);
            //}
            //return new ZipActionResult(files);

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
            var document = Doc.CreateFile(string.IsNullOrEmpty(form.Name) ? file.FileName : form.Name, form.Description, false,
                                    new FileInfo(path).FullName, container, _user.User);
            document.ContentLength = file.ContentLength;
            document.ContentType = MimeMapping.GetMimeMapping(file.FileName);
            document.Location = form.Location;

            _uow.Documents.Add(document);
            _uow.Save();

            return RedirectToAction<DocumentController>(c => c.Browse(document.Location));
        }


        [AllowAnonymous]
        public ActionResult Download(Guid id)
        {
            var file = _uow.Documents.FindById(id);
            return File(file.Path, MimeMapping.GetMimeMapping(file.Name), file.Name);
        }

        [AllowAnonymous]
        public ActionResult FileLink(Guid id)
        {
            var file = _uow.Documents.AllIncluding(c => c.Link).Where(d => d.Id == id).FirstOrDefault();

            if (file.Link == null)
            {
                file.CreateLink();
                _uow.Save();
            }

            var vm = new DocumentLinkModel()
            {
                Id = file.Id,
                Name = file.Name,
                Description = file.Description,
                Path = file.Path,
                ContentType = file.ContentType,
                ContentLength = file.ContentLength,
                SecurityCode = file.Link == null ? string.Empty : file.Link.SecurityCode,
                Created = file.Link.Created,
                Expire = file.Link.ExpireDate
            };
            //AutoMapper.Mapper.Map(file, vm);
            return View(vm);
        }

        public static IEnumerable<string> GenerateFileList(string directory)
        {
            var files = new List<string>();
            var empty = true;

            foreach (var file in Directory.GetFiles(directory))
            {
                files.Add(file);
                empty = false;
            }

            if (empty && Directory.GetDirectories(directory).Length == 0)
                files.Add(directory + @"/");

            files.AddRange(Directory.GetDirectories(directory).SelectMany(GenerateFileList));
            return files;
        }

    }

    public class ZipActionResult : FileResult
    {
        public IEnumerable<string> FilesToZip { set; get; }
        public ZipActionResult(IEnumerable<string> filesToZip)
            : base("application/zip")
        {
            FilesToZip = filesToZip;
        }
        protected override void WriteFile(HttpResponseBase response)
        {
            response.BufferOutput = false;

            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Cookies.Clear();
            response.ContentType = ContentType;
            response.ContentEncoding = Encoding.Default;
            response.AddHeader("Content-Type", ContentType);
            response.AddHeader("Content-Disposition",
                                    String.Format("attachment; filename={0}",
                                    this.FileDownloadName));
            byte[] buffer = new byte[4096];

            using (ZipOutputStream zipOutputStream =
                        new ZipOutputStream(response.OutputStream))
            {
                foreach (string fileName in FilesToZip)
                {
                    int folderOffset = fileName.LastIndexOf('\\');

                    Stream fs = System.IO.File.OpenRead(fileName);    // or any suitable inputstream
                    string entryName = fileName.Substring(folderOffset);
                    ZipEntry entry = new ZipEntry(ZipEntry.CleanName(entryName));
                    entry.Size = fs.Length;
                    // Setting the Size provides WinXP built-in extractor compatibility,
                    //  but if not available, you can set zipOutputStream.UseZip64 = UseZip64.Off instead.

                    zipOutputStream.PutNextEntry(entry);
                    //zipOutputStream.SetLevel(3); // 0-9 for compression level
                    //zipOutputStream.Password(); // security

                    int count = fs.Read(buffer, 0, buffer.Length);
                    while (count > 0)
                    {
                        zipOutputStream.Write(buffer, 0, count);
                        count = fs.Read(buffer, 0, buffer.Length);
                        if (!response.IsClientConnected)
                        {
                            break;
                        }
                        response.Flush();
                    }
                    fs.Close();
                }
                zipOutputStream.Finish();
            }
            //response.OutputStream.Flush();
            response.End();

        }
    }
}
