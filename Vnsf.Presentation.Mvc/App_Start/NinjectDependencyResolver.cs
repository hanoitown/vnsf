using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace Vnsf.Presentation.Mvc.App_Start
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this._kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this._kernel.BeginBlock());
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        IResolutionRoot _resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            this._resolver = resolver;
        }

        public object GetService(System.Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            var resolved = this._resolver.TryGet(serviceType);
            return resolved;
        }

        public IEnumerable<object> GetServices(System.Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return this._resolver.GetAll(serviceType);
        }

        public void Dispose()
        {
            var disposable = _resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            _resolver = null;
        }
    }
}