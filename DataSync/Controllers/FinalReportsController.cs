using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSync.Models;

namespace DataSync.Controllers
{
    public class FinalReportsController : Controller
    {
        private oms_nsEntities db = new oms_nsEntities();

        //
        // GET: /FinalReports/

        public ActionResult Index()
        {
            var vm = from fReport in db.tbl_finare_list
                     join project in db.basic_main on fReport.B_ID equals project.B_ID into projectTemp
                     from projects in projectTemp.DefaultIfEmpty()
                     join scientist in db.tbl_profile on fReport.userid equals scientist.S_ID
                     select new FinalReportBriefViewModel
                     {
                         ProjectName = fReport.project_name,
                         MainAuthor = scientist.S_NAME,
                         MainOrg = fReport.organization,
                         Sendtime = fReport.sendtime
                     };



            return View(vm.ToList());
        }

    }
}
