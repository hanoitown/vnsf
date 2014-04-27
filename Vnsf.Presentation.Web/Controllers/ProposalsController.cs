using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.Presentation.Web.Controllers
{
    public class ProposalsController : Controller
    {
        //
        // GET: /Proposals/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prepare()
        {
            return View();
        }
    }
}
