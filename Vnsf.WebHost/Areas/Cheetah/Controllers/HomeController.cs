using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Areas.Cheetah.Controllers
{
    public class HomeController : MvcBaseController
    {
        public HomeController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        //
        // GET: /Cheetah/Home/
        public ActionResult Index()
        {
            return View();
        }
    }
}