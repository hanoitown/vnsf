namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class WaterMarkConventionFilter : IModelMetadataInterface
    {
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata,
            System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName) && string.IsNullOrEmpty(metadata.Watermark))
                metadata.Watermark = metadata.DisplayName + " ...";
        }
    }
}