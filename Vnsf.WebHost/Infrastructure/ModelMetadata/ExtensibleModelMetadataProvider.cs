using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;


namespace Vnsf.WebHost.Infrastructure.ModelMetadata
{
    public class ExtensibleModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IModelMetadataInterface[] _metadataFilters;

        public ExtensibleModelMetadataProvider(IModelMetadataInterface[] metadataFilters)
        {
            _metadataFilters = metadataFilters;
        }

        protected override System.Web.Mvc.ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type typeContainer,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, typeContainer, modelAccessor, modelType, propertyName);
            _metadataFilters.ForEach(m => m.TransformMetadata(metadata, attributes));
            return metadata;
        }
    }
}