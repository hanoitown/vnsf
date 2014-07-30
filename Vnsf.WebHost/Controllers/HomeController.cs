using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Controllers
{
    public class HomeController : MvcBaseController
    {
        public HomeController(IUnitOfWork uow)
            : base(uow)
        {

        }
        public ActionResult Index()
        {

            return View();
        }
    }
}
