using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class HostingDropDownFilter : IModelMetadataInterface
    {
        string cultureFieldName = "hostingid";
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && cultureFieldName.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "HostingId";
            }
        }
    }
}