using System.Collections.Generic;
using System.Security.AccessControl;
using Elmah.Assertions;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class TextAreaByNameFilter : IModelMetadataInterface
    {
        static HashSet<string> TextAreaFieldNames = new HashSet<string>
                                    {
                                          "description","body","comment", "content","note","abstract"
                                    };
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && TextAreaFieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "MultilineText";
            }

        }
    }
}