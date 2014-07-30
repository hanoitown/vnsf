using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;

namespace Vnsf.WebHost.Controllers
{
    public class NewsController  : MvcBaseController
    {
        public NewsController(IUnitOfWork uow)
            : base(uow)
        {

        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post()
        {
            return View();
        }
    }
}