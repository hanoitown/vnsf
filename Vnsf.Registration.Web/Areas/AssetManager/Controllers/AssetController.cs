using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.Registration.Web.Areas.AssetManager.Controllers
{
    public class AssetController : Controller
    {
        //
        // GET: /AssetManager/Asset/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
