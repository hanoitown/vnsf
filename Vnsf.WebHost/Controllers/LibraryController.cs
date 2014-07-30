using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;

namespace Vnsf.WebHost.Controllers
{
    public class LibraryController : MvcBaseController
    {
        public LibraryController(IUnitOfWork uow)
            : base(uow)
        {

        }
        // GET: Library
        public ActionResult Index()
        {
            // get list of document belong to document library

            return View();
        }
    }
}