using System.Linq;
using StructureMap;
using StructureMap.Graph;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Vnsf.Data.EF;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Repository;
using StructureMap.Configuration.DSL;

namespace Vnsf.WebHost.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var assemblies = new[] { "Vnsf.Data.EF", "Vnsf.Data.Repository", "Vnsf.Infrastructure", "Vnsf.Service.Contract", "Vnsf.Service.Implementation" };

            ObjectFactory.Initialize(x =>
                        {

                            x.Scan(scan =>
                                    {
                                        scan.AssembliesFromApplicationBaseDirectory(assembly => assemblies.Contains(assembly.FullName));
                                        scan.IncludeNamespace("Vnsf");
                                    });

                            //x.For<IUnitOfWork>().Use<UnitOfWork>();

                            //x.For<IControllerActivator>().Use<StructureMapControllerActivator>();
                        });
            return ObjectFactory.Container;
        }
    }

    public class StructureMapControllerActivator : IControllerActivator
    {
        public StructureMapControllerActivator(IContainer container)
        {
            _container = container;
        }
        private IContainer _container;
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return _container.GetInstance(controllerType) as IController;
        }
    }
}
