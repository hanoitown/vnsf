namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class DropDownFilterForOpportunity : IModelMetadataInterface
    {
        string FieldNames = "opportunityid";
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && FieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "OpportunityId"; 
            }
        }
    }
}