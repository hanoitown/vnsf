using WebGrease.Css.Ast.MediaQuery;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class ReadOnlyTemplateFilter : IModelMetadataInterface
    {
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (metadata.IsReadOnly && string.IsNullOrEmpty(metadata.DataTypeName))
                metadata.DataTypeName = "ReadOnly";
        }
    }
}