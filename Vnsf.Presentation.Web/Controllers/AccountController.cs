using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Http;
using Vnsf.Presentation.Web.Models;

namespace Vnsf.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /UserAccount/
        [HttpGet]
        [GET("/account/login")]
        public ActionResult Login(string returnUrl)
        {
            return View(new AccountLoginModel()
                            {
                                ReturnUrl = returnUrl
                            });
        }


        [HttpGet]
        [GET("/account/register")]
        public ActionResult Register(string returnUrl)
        {
            return View(new AccountLoginModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpGet]
        [GET("/account/settings")]
        public ActionResult Settings()
        {
            return View();
        }

    }
}
