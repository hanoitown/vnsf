using WebApiContrib.IoC.Ninject;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Vnsf.Presentation.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Vnsf.Presentation.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Vnsf.Presentation.Web.App_Start
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
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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

            //Support WebAPI
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
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
}
