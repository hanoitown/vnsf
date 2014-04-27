using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.EF;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Data.Repository;
using Vnsf.Service.Implementation;

namespace Vnsf.Presentation.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private UserAccountService _userAccountService;

        public HomeController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        public ActionResult Index()
        {
            _userAccountService.CreateAccount("hanm", "hanm", "ha@hanoitown.com");
            return View();
        }
    }
}