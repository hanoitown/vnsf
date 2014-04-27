using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Building;
using System.Web.Mvc;
using StructureMap;

namespace Vnsf.WebHost.Infrastructure.DI
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;
            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                         ? ObjectFactory.GetInstance(serviceType)
                         : ObjectFactory.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
        }
    }
}