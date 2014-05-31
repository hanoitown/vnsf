using System.Collections.Generic;
namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class EmailInputByNameFilter : IModelMetadataInterface
    {

        static HashSet<string> EmailFieldNames = new HashSet<string>
                                    {
                                          "email"             
                                    };
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && EmailFieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "EmailAddress";
            }

        }
    }
}