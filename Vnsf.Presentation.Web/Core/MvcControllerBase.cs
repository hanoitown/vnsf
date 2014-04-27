using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.Presentation.Web.Core
{
    public class MvcControllerBase : Controller
    {
        //
        // GET: /MvcControllerBase/

        public ActionResult Index()
        {
            return View();
        }

    }
}
