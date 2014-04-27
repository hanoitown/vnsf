using System.Data.Entity;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vnsf.Data.EF.Samples;
using Vnsf.Registration.Web.Controllers;
using Vnsf.Service.Data;

namespace Vnsf.Registration.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // create empty config database if it not exists
            Database.SetInitializer(new VnsfDatabaseInitializer());
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            AreaRegistration.RegisterAllAreas();
            AutoMapperBootStrapper.ConfigureAutoMapper();
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

        }
    }
}