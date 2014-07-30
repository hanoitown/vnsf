using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;
using Microsoft.Web.Mvc;
using Vnsf.WebHost.Infrastructure.Alerts;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Entities;
using System.Threading.Tasks;
using Vnsf.WebHost.Areas.Manage.Models;
using Vnsf.WebHost.Infrastructure;
using Vnsf.Data;
using System.IO;
using Vnsf.Data.Entities.Registration;


namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class ApplicationFormController : MvcBaseController
    {
        ICurrentUser _user;
        AppConfiguration _config;
        public ApplicationFormController(IUnitOfWork uow, ICurrentUser user)
            : base(uow)
        {
            _user = user;
            _config = new AppConfiguration(AppSettings.Instance);
        }

        public ActionResult Index()
        {
            var vm = _uow.AppForms.AllIncluding(o => o.Opportunity)
                                    .Project().To<AppFormViewModel>();

            return View(vm);
        }

        // GET: Manage/ApplicationItem/Create
        public ActionResult Create()
        {
            ViewData["Opportunities"] = _uow.Opps.All
                       .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), string.Empty);

            var vm = new AppFormBindingModel();
            return View(vm);
        }

        // POST: Manage/ApplicationItem/Create
        [HttpPost]
        public async Task<ActionResult> Create(AppFormBindingModel form, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var opp = await _uow.Opps.FindAsyncById(form.OpportunityId);
                    var app = new ApplicationForm
                        {
                            Id = Guid.NewGuid(),
                            Code = form.Code,
                            Name = form.Name,
                            Description = form.Description,
                            Opportunity = opp

                        };

                    //if (file != null)
                    //{
                    //    var saveFileName = Path.Combine(Server.MapPath("/documents/public/"), file.FileName);
                    //    file.SaveAs(saveFileName);

                    //    app.Path = saveFileName;
                    //    app.IsFolder = false;
                    //    app.ContentLength = file.ContentLength;
                    //    app.ContentType = MimeMapping.GetMimeMapping(file.FileName);

                    //}

                    _uow.AppForms.Add(app);
                    await _uow.SaveAsync();


                }

                return RedirectToAction<ApplicationFormController>(c => c.Index()).WithSuccess("Created");
            }
            catch (Exception ex)
            {
                return RedirectToAction<ApplicationFormController>(c => c.Index()).WithError("Failed " + ex.Message);
            }
        }

        // GET: Manage/ApplicationItem/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = _uow.AppForms.AllIncluding(g => g.Opportunity).First(g => g.Id == id);
            var vm = AutoMapper.Mapper.Map<AppFormBindingModel>(item);

            ViewData["Opportunities"] = _uow.Opps.All
                       .ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), item.Id.ToString());

            return View(vm);
        }

        // POST: Manage/ApplicationItem/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, AppFormBindingModel form, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var opt = _uow.Opps.FindById(form.OpportunityId);

                    var item = _uow.AppForms.FindById(id);
                    item.Name = form.Name;
                    item.Code = form.Code;
                    item.Description = form.Description;
                    item.Opportunity = opt;

                    //if (file != null)
                    //{
                    //    var savePath = Path.Combine(Server.MapPath("/documents/public/"), file.FileName);

                    //    file.SaveAs(savePath);
                    //    item.Path = savePath;
                    //    item.ContentLength = file.ContentLength;
                    //    item.ContentType = file.ContentType;

                    //    System.IO.File.Delete(item.Path);
                    //}

                    await _uow.SaveAsync();

                    return RedirectToAction<ApplicationFormController>(c => c.Index()).WithSuccess("Updated");
                }

                return RedirectToAction<ApplicationFormController>(c => c.Index()).WithError("Update failed");

            }
            catch
            {
                return View();
            }
        }

        // POST: Manage/ApplicationItem/Delete/5
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
