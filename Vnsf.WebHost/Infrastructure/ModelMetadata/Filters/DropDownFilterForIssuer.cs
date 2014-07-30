namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class DropDownFilterForIssuer : IModelMetadataInterface
    {
        string IssuerFieldNames = "issuerid";
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && IssuerFieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "IssuerId"; 
            }
        }
    }
}