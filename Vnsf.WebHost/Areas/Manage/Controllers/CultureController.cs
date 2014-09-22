using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;
using Vnsf.WebHost.Models;
using Microsoft.Web.Mvc;
using Vnsf.WebHost.Infrastructure.Alerts;
using Vnsf.Data.Entities;
using System.Threading.Tasks;
using Vnsf.WebHost.Areas.Manage.Models;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.WebHost.Areas.Manage.Controllers
{
    public class CultureController : MvcBaseController
    {
        public CultureController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public ActionResult Index()
        {
            // get culture list
            var data = _uow.Cultures.All;

            // get localized data in current culture
            var locale = _uow.LocalCultures.AllIncluding(c => c.DestCulture).Where(c => c.DestCulture.Code == this.CurrentCulture);

            var vm = data.GroupJoin(locale,
                            p => p.Id,
                            c => c.Culture.Id,
                            (p, g) => g.Select(c => new CultureViewModel { Id = p.Id, Code = p.Code, Name = c.Name, ISO2 = p.ISO2, ISO3 = p.ISO3 })
                                       .DefaultIfEmpty(new CultureViewModel { Id = p.Id, Code = p.Code, Name = p.Name, ISO2 = p.ISO2, ISO3 = p.ISO3 }))
                            .SelectMany(g => g);

            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult CultureLocal(Guid id)
        {
            var vm = _uow.LocalCultures.AllIncluding(l => l.DestCulture).Where(c => c.Culture.Id == id)
                            .Project().To<CultureLocalViewModel>();

            return PartialView("_CultureLocal", vm);
        }

        public ActionResult CultureLocalAdd(Guid id)
        {
            var vm = new CultureLocalBindModel();
            ViewData["Cultures"] = _uow.Cultures.All.ToSelectList(c => c.Id.ToString(), c => c.Name.ToString(), id.ToString());

            return View("_CultureLocalAdd", vm);
        }

        public ActionResult CultureLocalRemove(Guid id)
        {
            var item = _uow.LocalCultures.FindById(id);
            _uow.LocalCultures.Remove(item);
            _uow.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CultureLocalAdd(Guid id, CultureLocalBindModel form)
        {
            try
            {
                var item = _uow.Cultures.AllIncluding(c => c.Localizeds).FirstOrDefault(c => c.Id == id);
                var culture = _uow.Cultures.FindById(form.DestCultureId);

                item.AddLocale(form.Name, culture);
                _uow.Save();

                return RedirectToAction<CultureController>(c => c.Edit(id)).WithSuccess("Done");

            }
            catch (Exception ex)
            {

                return RedirectToAction<CultureController>(c => c.Edit(id)).WithError(ex.Message);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CultureViewModel form)
        {
            try
            {
                // TODO: Add insert logic here
                _uow.Cultures.Add(Culture.New(form.Name, form.Code, form.ISO2, form.ISO3));
                _uow.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var item = _uow.Cultures.AllIncluding(c => c.Localizeds).FirstOrDefault(c => c.Id == id);

            var vm = AutoMapper.Mapper.Map<CultureBindModel>(item);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, CultureViewModel form)
        {
            try
            {
                var item = _uow.Cultures.FindById(id);
                item.Name = form.Name;
                item.Code = form.Code;
                item.ISO2 = form.ISO2;
                item.ISO3 = form.ISO3;
                _uow.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manage/Culture/Delete/5
        public ActionResult Delete(Guid id)
        {
            var item = _uow.Cultures.FindById(id);
            _uow.Cultures.Remove(item);
            _uow.Save();

            return RedirectToAction("Index");
        }

        //
        // POST: /Manage/Culture/Delete/5
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
