using System;
using System.Collections.Generic;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata
{
    public interface IModelMetadataInterface
    {
        void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, IEnumerable<Attribute> attributes);
    }
}