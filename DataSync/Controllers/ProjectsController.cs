using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSync.Models;

namespace DataSync.Controllers
{
    public class ProjectsController : Controller
    {
        private oms_nsEntities db = new oms_nsEntities();

        //
        // GET: /Projects/


        public ActionResult Index(int ProgramId, string fId)
        {
            var project = db.basic_main.Where(p => p.T_ID == ProgramId && p.B_MAJOR == fId);
            return View(project.ToList());
        }
        public ActionResult Review(int ProgramId, string fId)
        {
            var query = from projects in db.basic_main
                        where projects.T_ID == ProgramId && projects.B_MAJOR == fId
                        join register in db.tbl_main_profile on projects.B_ID equals register.B_ID into projectsRegister
                        from registerProject in projectsRegister.DefaultIfEmpty()
                        where registerProject.B_ROLE == "Chủ nhiệm đề tài"
                        join scientist in db.tbl_profile on registerProject.S_ID equals scientist.S_ID
                        orderby projects.B_CODE descending
                        select new ReviewModel
                        {
                            Code = projects.B_CODE,
                            Project = projects.B_NAME_E,
                            PI = scientist.S_NAME,
                            Role = registerProject.B_ROLE,
                            Reviews = db.tbl_review.Where(r => r.b_id == projects.B_ID)
                                                        .Select(o => new ReviewBrief
                                                        {
                                                            Status = o.status,
                                                            Reviewer = o.userid
                                                        })
                        };
            return View(query.ToList());
        }


        //
        // GET: /Projects/Details/5

        public ActionResult Details(string code)
        {
            var vm = (from project in db.basic_main
                      where project.B_CODE == code
                      select new ProjectViewModel
                                 {
                                     Code = project.B_CODE,
                                     Name = project.B_NAME_V,
                                     Abstract = project.B_ABSTRACT_V,
                                     Duration = project.B_MONTH_NUMBER,
                                     Expense = project.B_TOTAL_EXPENSE,
                                     Field = project.B_FIELD,
                                     FromDate = project.B_FROM,
                                     ToDate = project.B_TO,
                                     Group = project.B_GROUP,
                                     Human = project.B_PEOPLE_NUMBER,
                                     Reviews = from reviews in db.tbl_review where reviews.b_id == project.B_ID select reviews,
                                     Reports = from reports in db.tbl_report where reports.B_ID == project.B_ID select reports,
                                     Members = from submission in db.tbl_main_profile where submission.B_ID == project.B_ID
                                               join scientist in db.tbl_profile on submission.S_ID equals scientist.S_ID into members
                                               from projectMembers in members.DefaultIfEmpty()
                                               select new MemberViewModel
                                                          {
                                                              Name = projectMembers.S_NAME,
                                                              Role = submission.B_ROLE
                                                          }


                                 }).FirstOrDefault();
            if (vm == null)
                return HttpNotFound();
            return View(vm);
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Projects/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(basic_main basic_main)
        {
            if (ModelState.IsValid)
            {
                db.basic_main.Add(basic_main);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basic_main);
        }

        //
        // GET: /Projects/Edit/5

        public ActionResult Edit(int id = 0)
        {
            basic_main basic_main = db.basic_main.Find(id);
            if (basic_main == null)
            {
                return HttpNotFound();
            }
            return View(basic_main);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(basic_main basic_main)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basic_main).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basic_main);
        }

        //
        // GET: /Projects/Delete/5

        public ActionResult Delete(int id = 0)
        {
            basic_main basic_main = db.basic_main.Find(id);
            if (basic_main == null)
            {
                return HttpNotFound();
            }
            return View(basic_main);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            basic_main basic_main = db.basic_main.Find(id);
            db.basic_main.Remove(basic_main);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}