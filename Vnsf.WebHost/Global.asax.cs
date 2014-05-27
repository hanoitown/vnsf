using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vnsf.Data.EF.DataContexts;
using Vnsf.Data.EF.Samples;
using Vnsf.WebHost.Infrastructure.Mapping;
using Vnsf.WebHost.Infrastructure.Tasks;

namespace Vnsf.WebHost
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //VnsfDbInit.InitDb();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
            //AutoMapperBootstrapper.Init();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            foreach (var task in DependencyResolver.Current.GetServices<IRunAtInit>())
            {
                task.Execute();
            }

            foreach (var task in DependencyResolver.Current.GetServices<IRunAtStartup>())
            {
                task.Execute();
            }
        }

        public void Application_BeginRequest()
        {
            foreach (var task in DependencyResolver.Current.GetServices<IRunOnEachRequest>())
            {
                task.Execute();
            }

            AutoMapperBootstrapper.RunInit();
        }

        public void Application_EndRequest()
        {
            foreach (var task in DependencyResolver.Current.GetServices<IRunAfterEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in DependencyResolver.Current.GetServices<IRunOnError>())
            {
                task.Execute();
            }
        }
    }
}
