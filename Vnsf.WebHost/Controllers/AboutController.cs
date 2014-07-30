using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;

namespace Vnsf.WebHost.Controllers
{
    public class AboutController : MvcBaseController
    {
        public AboutController(IUnitOfWork uow)
            : base(uow)
        {

        }

        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}