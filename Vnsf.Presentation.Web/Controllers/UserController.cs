﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.Presentation.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Storage/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}