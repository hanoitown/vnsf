namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class ClassificationDropDownFilter : IModelMetadataInterface
    {
        string ClassificationFieldNames = "classificationid";
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && ClassificationFieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "ClassificationId"; 
            }
        }
    }
}