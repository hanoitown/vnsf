using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;
using Vnsf.Data.EF;
using Vnsf.Data.Helpers;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Repository;
using Vnsf.WebHost.DependencyResolution;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Vnsf.WebHost.App_Start.StructuremapMvc), "Start")]

namespace Vnsf.WebHost.App_Start
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            //IContainer container = IoC.Initialize();
            IContainer container = new Container(x =>
            {
                x.For<IControllerActivator>().Use<StructureMapControllerActivator>();
                x.For<IUnitOfWork>().Use<UnitOfWork>();
                x.For(typeof (IRepository<>)).Use(typeof (Repository<>));
                x.For<IRepositoryProvider>().Use<RepositoryProvider>();
            });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}