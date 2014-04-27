using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSync.Models;

namespace DataSync.Controllers
{
    public class ReportsController : Controller
    {
        private oms_nsEntities db = new oms_nsEntities();
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            var vm = from reports in db.tbl_report
                     join projects in db.basic_main on reports.B_ID equals projects.B_ID into report
                     from rpt in report.DefaultIfEmpty()
                     select new ReportViewModel
                                {
                                    Id = reports.R_ID,
                                    ProjectCode = rpt.B_CODE,
                                    Created = reports.R_CREATED_DATE,
                                    Update = reports.R_UPDATE_DATE,
                                    Submitted = reports.R_SUBMITTED_DATE
                                };
            return View(vm.ToList());
        }

        public ActionResult Details(int rId)
        {
            var vm = from reports in db.tbl_report
                     where reports.R_ID == rId
                     select new ReportDetailViewModel
                                {
                                    Done = reports.R_DONE,
                                    Quality = reports.R_QUALITY,
                                    Next = reports.R_NEXT,
                                    Conclusion = reports.R_CONCLUSION

                                };
            return View(vm.FirstOrDefault());
        }
    }
}
