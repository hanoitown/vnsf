using System;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
{
    readonly IKernel kernel;

    public NinjectDependencyResolver(IKernel kernel)
        : base(kernel)
    {
        this.kernel = kernel;
    }

    public IDependencyScope BeginScope()
    {
        return new NinjectDependencyScope(this.kernel.BeginBlock());
    }
}

public class NinjectDependencyScope : IDependencyScope
{
    IResolutionRoot resolver;

    public NinjectDependencyScope(IResolutionRoot resolver)
    {
        this.resolver = resolver;
    }

    public object GetService(System.Type serviceType)
    {
        if (resolver == null)
            throw new ObjectDisposedException("this", "This scope has been disposed");

        var resolved = this.resolver.Get(serviceType);
        return resolved;
    }

    public System.Collections.Generic.IEnumerable<object> GetServices(System.Type serviceType)
    {
        if (resolver == null)
            throw new ObjectDisposedException("this", "This scope has been disposed");

        return this.resolver.GetAll(serviceType);
    }

    public void Dispose()
    {
        IDisposable disposable = resolver as IDisposable;
        if (disposable != null)
            disposable.Dispose();

        resolver = null;
    }
}