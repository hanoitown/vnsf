using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Contracts;
using Vnsf.Registration.Web.Utility;

namespace Vnsf.Registration.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IUow Uow { get; set; }
        protected CultureInfo Culture { set; get;}

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Is it View ?
            var view = filterContext.Result as ViewResultBase;
            if (view == null) // if not exit
                return;

            string cultureName = Thread.CurrentThread.CurrentCulture.Name; // e.g. "en-US" // filterContext.HttpContext.Request.UserLanguages[0]; // needs validation return "en-us" as default            

            // Is it default culture? exit
            if (cultureName == CultureHelper.GetDefaultCulture())
                return;


            // Are views implemented separately for this culture?  if not exit
            bool viewImplemented = CultureHelper.IsViewSeparate(cultureName);
            if (viewImplemented == false)
                return;

            string viewName = view.ViewName;

            int i = 0;

            if (string.IsNullOrEmpty(viewName))
                viewName = filterContext.RouteData.Values["action"] + "." + cultureName; // Index.en-US
            else if ((i = viewName.IndexOf('.')) > 0)
            {
                // contains . like "Index.cshtml"                
                viewName = viewName.Substring(0, i + 1) + cultureName + viewName.Substring(i);
            }
            else
                viewName += "." + cultureName; // e.g. "Index" ==> "Index.en-Us"

            view.ViewName = viewName;

            filterContext.Controller.ViewBag._culture = "." + cultureName;

            base.OnActionExecuted(filterContext);
        }

        protected override void ExecuteCore()
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            cultureName = cultureCookie != null ? cultureCookie.Value : Request.UserLanguages[0];

            // Validate culture name
            cultureName = CultureHelper.GetValidCulture(cultureName); // This is safe


            // Modify current thread's cultures      
            CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo(cultureName);
            CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo(cultureName);
            base.ExecuteCore();
        }
    }
}
