using System.Collections.Generic;
namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class PasswordInputByNameFilter : IModelMetadataInterface
    {

        static HashSet<string> PasswordFieldNames = new HashSet<string>
                                    {
                                          "password"             
                                    };
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && PasswordFieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "Password";
            }

        }
    }
}