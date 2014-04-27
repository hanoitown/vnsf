using System.Net;
using System.Security.Principal;
using System.Web;
using Ninject.Modules;

namespace Vnsf.WebHost.Infrastructure
{
    public class MvcDIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IIdentity>().ToMethod(context => HttpContext.Current.User.Identity);
            Bind<HttpSessionStateBase>()
                .ToMethod(context => new HttpSessionStateWrapper(HttpContext.Current.Session));
            //Bind<HttpContextBase>()
            //    .ToMethod(context => new HttpContextWrapper(HttpContext.Current));
            Bind<HttpServerUtilityBase>()
                .ToMethod(context => new HttpServerUtilityWrapper(HttpContext.Current.Server));
        }
    }
}