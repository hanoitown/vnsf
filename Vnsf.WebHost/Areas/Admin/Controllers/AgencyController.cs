using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data;

namespace Vnsf.WebHost.Areas.Admin.Controllers
{
    public class AgencyController : Controller
    {
        private VnsfDbContext db = new VnsfDbContext();

        // GET: /Admin/Agency/
        public ActionResult Index()
        {
            return View(db.Organizations.ToList().OfType<FundingAgency>());
        }

        // GET: /Admin/Agency/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FundingAgency fundingagency = (FundingAgency)db.Organizations.Find(id);
            if (fundingagency == null)
            {
                return HttpNotFound();
            }
            return View(fundingagency);
        }

        // GET: /Admin/Agency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Agency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,ShortName,Phone,Email,Website,IsPublic")] FundingAgency fundingagency)
        {
            if (ModelState.IsValid)
            {
                fundingagency.Id = Guid.NewGuid();
                db.Organizations.Add(fundingagency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fundingagency);
        }

        // GET: /Admin/Agency/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FundingAgency fundingagency = (FundingAgency)db.Organizations.Find(id);
            if (fundingagency == null)
            {
                return HttpNotFound();
            }
            return View(fundingagency);
        }

        // POST: /Admin/Agency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,ShortName,Phone,Email,Website,IsPublic")] FundingAgency fundingagency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fundingagency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fundingagency);
        }

        // GET: /Admin/Agency/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FundingAgency fundingagency = (FundingAgency)db.Organizations.Find(id);
            if (fundingagency == null)
            {
                return HttpNotFound();
            }
            return View(fundingagency);
        }

        // POST: /Admin/Agency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FundingAgency fundingagency = (FundingAgency)db.Organizations.Find(id);
            db.Organizations.Remove(fundingagency);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
