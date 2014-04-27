using System.Web.Http;
using Ninject;
using Vnsf.Data;
using Vnsf.Data.Contracts;
using Vnsf.Data.EF;
using Vnsf.Data.Helpers;

namespace Vnsf.Registration.Web.App_Start
{
    public class IocConfig
    {

        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IUow>().To<VnsfUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }

    }
}