using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;

namespace Vnsf.WebHost.Controllers
{
    public class OpportunitiesController : MvcBaseController
    {
        public OpportunitiesController(IUnitOfWork uow)
            : base(uow)
        {

        }
        // GET: Opportunities
        public ActionResult Index()
        {
            return View();
        }
    }
}