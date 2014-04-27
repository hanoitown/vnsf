using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Service.Contract.Service_Contracts;
using Vnsf.WebHost.Models;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class AnnouncementsController : Controller
    {
        IInformationService _svc;
        public AnnouncementsController(IInformationService grantSvc)
        {
            _svc = grantSvc;
        }
        public AnnouncementsController()
        {

        }

        //
        // GET: /Admin/Announcements/
        public ActionResult Index()
        {
            var vm = _svc.GetAvailableAnnouncements().Select(a => new AnnouncementViewModel(a));
            return View(vm);
        }

        //
        // GET: /Admin/Announcements/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Announcements/Create
        public ActionResult Create()
        {
            var opportunities = _svc.GetAvailableOpportunities();
            var vm = new AnnouncementBindingModel(new Announcement
                                                  {
                                                      StartDate = DateTime.UtcNow,
                                                      Deadline = DateTime.UtcNow,
                                                      PostDate = DateTime.UtcNow
                                                  }, opportunities);
            return View(vm);
        }

        //
        // POST: /Admin/Announcements/Create
        [HttpPost]
        public ActionResult Create(Announcement announcement)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                    _svc.CreateAnnoucement(announcement);

                return RedirectToAction("Index");
            }
            catch
            {
                var opportunities = _svc.GetAvailableOpportunities();
                var vm = new AnnouncementBindingModel(announcement, opportunities);

                return View(vm);
            }
        }

        //
        // GET: /Admin/Announcements/Edit/5
        public ActionResult Edit(Guid id)
        {
            var opportunities = _svc.GetAvailableOpportunities();
            var announcement = _svc.GetAnnouncementsById(id);
            var vm = new AnnouncementBindingModel(announcement, opportunities);

            return View(vm);
        }

        //
        // POST: /Admin/Announcements/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Announcement announcement)
        {
            try
            {
                // TODO: Add update logic here
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                    _svc.PutAnnoucement(id, announcement);

                return RedirectToAction("Index");
            }
            catch
            {
                var opportunities = _svc.GetAvailableOpportunities();
                var vm = new AnnouncementBindingModel(announcement, opportunities);

                return View(vm);
            }
        }

        //
        // GET: /Admin/Announcements/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Announcements/Delete/5
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
