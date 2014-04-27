using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Contracts;
using Vnsf.Registration.Web.Utility;
using Vnsf.Service.Contract;

namespace Vnsf.Registration.Web.Controllers
{
    public class HomeController : Controller
    {
        protected IUow Uow { get; set; }
        public IAuthorizationService AuthorizationService { get; set; }

        public HomeController(IAuthorizationService authorizationService)
        {
            AuthorizationService = authorizationService;
        }

        public ActionResult ChangeCulture(string lang)
        {
            var langCookie = new HttpCookie("_culture", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);
            return RedirectToAction("Index", "Home", new { culture = lang });
        }

        public ActionResult Index()
        {
            return View(AuthorizationService.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetValidCulture(culture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {

                cookie = new HttpCookie("_culture");
                cookie.HttpOnly = false; // Not accessible by JS.
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }


    }
}
