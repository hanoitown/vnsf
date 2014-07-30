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

            // get local for current culture
            var locale = _uow.LocalCultures.AllIncluding(c => c.Culture).Where(c => c.Culture.Code == this.CurrentCulture);

            var vm = data.GroupJoin(locale,
                            p => p.Id,
                            c => c.Culture.Id,
                            (p, g) => g.Select(c => new CultureViewModel { Id = p.Id, Code = p.Code, Name = c.Name, ISO2 = p.ISO2, ISO3 = p.ISO3 })
                                       .DefaultIfEmpty(new CultureViewModel { Id = p.Id, Code = p.Code, Name = p.Name, ISO2 = p.ISO2, ISO3 = p.ISO3 }))
                            .SelectMany(g => g);

            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult LocalCulture(string cultureCode)
        {
            var lc = _uow.LocalCultures.AllIncluding(l => l.Culture).Where(c => c.Culture.Code == cultureCode);

            return View(lc);
        }

        
        public ActionResult Details(Guid id)
        {
            var item = _uow.Cultures.AllIncluding(c => c.Localizeds).FirstOrDefault(c => c.Id == id);
            var vm = AutoMapper.Mapper.Map<CultureViewModel>(item);

            return View(vm);
        }

        //
        // GET: /Manage/Culture/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manage/Culture/Create
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

        //
        // GET: /Manage/Culture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Culture/Edit/5
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
