using log4net;
using Ninject.Modules;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Vnsf.Infrastructure.Repository;
using Vnsf.WebHost.Areas.Cheetah.Controllers;
using Vnsf.WebHost.Infrastructure;
using Vnsf.WebHost.Infrastructure.ModelMetadata;
using Vnsf.WebHost.Infrastructure.Tasks;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Vnsf.WebHost.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Vnsf.WebHost.App_Start.NinjectWebCommon), "Stop")]

namespace Vnsf.WebHost.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;
    using Ninject.Extensions.Conventions;
    using System.Data.Entity;
    using Vnsf.Data;
    using System.Web.Mvc;
    using Vnsf.WebHost.Filters;
    using Vnsf.Data.EF;
    using Vnsf.Data.Repository;

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
            var modules = new NinjectModule[]
                          {
                              new TaskRegisterModule(), 
                              new MetadataProviderModule(), 
                              new MvcDIModule()
                          };
            var kernel = new StandardKernel(modules);
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
            //kernel.Bind<DbContext>().To<VnsfDbContext>();

            //kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            kernel.Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Request.Target.Member.DeclaringType));

            kernel.BindFilter<LogFilter>(FilterScope.Action, 0)
                .When((controllerContext, actionDescriptor) =>
                    actionDescriptor.ControllerDescriptor.ControllerType == typeof(OpportunityController) &&
                    actionDescriptor.ActionName == "ActionName");

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

            kernel.Bind(x => x
                     .FromAssembliesMatching("Vnsf.*.dll")
                     .SelectAllClasses()
                     .Excluding<UnitOfWork>()
                     .BindAllInterfaces());

        }
    }
}
