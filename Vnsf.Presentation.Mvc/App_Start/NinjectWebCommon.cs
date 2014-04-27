
using System.Linq;
using Ninject.Modules;
using Vnsf.Data;
using Vnsf.Data.EF;
using Vnsf.Data.Repository;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Vnsf.Presentation.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Vnsf.Presentation.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace Vnsf.Presentation.Mvc.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();


            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            RegisterServices(kernel);

            return kernel;
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind(x => x
            //               .FromThisAssembly()
            //               .SelectAllTypes()
            //               .BindAllInterfaces()
            //               );

            //kernel.Bind(x => x
            //                     .FromAssemblyContaining(typeof(CultureService))
            //                     .SelectAllTypes()
            //                     .BindAllInterfaces());
            kernel.Bind(x => x
                     .FromAssembliesMatching("Vnsf.*.dll")
                     .SelectAllClasses()
                     .BindAllInterfaces());
            //kernel.Bind<IDbContext>().To<VnsfDbContext>();
            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            //kernel.Bind<ICultureRepository>().ToMethod(ctx => new CultureRepository()).InRequestScope();
        }
    }

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var respositoryAssembly = typeof(MvcApplication).Assembly;

            var registrations = from type in respositoryAssembly.GetExportedTypes()
                                where type.Namespace.Contains("Model")
                                where type.GetInterfaces().Any()
                                select new
                                {
                                    Service = type.GetInterfaces().First(),
                                    Implementation = type
                                };
            foreach (var registration in registrations)
            {
                Kernel.Bind(registration.Service).To(registration.Implementation).InTransientScope();
            }
        }

    }
}
