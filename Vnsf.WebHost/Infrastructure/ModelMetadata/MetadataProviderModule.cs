using System.Web.Mvc;
using Ninject.Modules;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata
{
    public class MetadataProviderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ModelMetadataProvider>().To<ExtensibleModelMetadataProvider>();
        }
    }
}