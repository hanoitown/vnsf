using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Vnsf.Data;
using Vnsf.Data.Contracts;
using Vnsf.Data.EF;
using Vnsf.Data.Helpers;
using Vnsf.Service.Contract;
using Vnsf.Service.Implementation;

namespace Vnsf.Registration.Web.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;
        public IoCControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)_kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
            _kernel.Bind<IGlobalizationSettings>().To<GlobalizationSettings>();
            _kernel.Bind<IAuthorizationService>().To<AuthorizationService>();
            _kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            _kernel.Bind<IUow>().To<VnsfUow>();
        }
    }
}