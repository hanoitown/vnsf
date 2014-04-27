using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class CultureDropDownFilter : IModelMetadataInterface
    {
        string cultureFieldName = "cultureid";
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && cultureFieldName.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "CultureId";
            }
        }
    }
}