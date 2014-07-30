using System.Collections.Generic;
namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class DropDownFilterForCategory : IModelMetadataInterface
    {
        static HashSet<string> FieldNames = new HashSet<string>
                                    {
                                          "parentid","fieldid"
                                    };
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (string.IsNullOrEmpty(metadata.DataTypeName) && !string.IsNullOrEmpty(metadata.PropertyName) && FieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "ParentId";
            }
        }
    }
}