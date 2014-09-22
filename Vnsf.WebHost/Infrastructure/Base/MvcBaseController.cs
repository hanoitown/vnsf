using Microsoft.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Filters;
using System.Threading;
using System.Globalization;
using Vnsf.WebHost.Infrastructure;
using Vnsf.WebHost.Models;
using AutoMapper.QueryableExtensions;
using Vnsf.Data;

namespace Vnsf.WebHost
{
    public class MvcBaseController : Controller
    {
        //protected ModelFactory _modelFactory;
        protected IUnitOfWork _uow;
        protected AppConfiguration _config;

        public MvcBaseController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _config = new AppConfiguration(AppSettings.Instance);
        }

        public MvcBaseController()
        {
        }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }

        protected string CurrentCulture
        {
            get
            {
                HttpCookie cookie = Request.Cookies["_culture"];
                if (cookie != null)
                    return cookie.Value;
                else
                    return CultureHelper.GetDefaultCulture();
            }
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.ToString());
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];

            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}