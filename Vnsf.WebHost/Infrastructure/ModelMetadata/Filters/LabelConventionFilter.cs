using System.Text.RegularExpressions;

namespace Vnsf.WebHost.Infrastructure.ModelMetadata.Filters
{
    public class LabelConventionFilter : IModelMetadataInterface
    {
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, System.Collections.Generic.IEnumerable<System.Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName) && string.IsNullOrEmpty(metadata.DisplayName))
                metadata.DisplayName = GetStringWithSpace(metadata.PropertyName);
        }

        private string GetStringWithSpace(string p)
        {
            return Regex.Replace(p,
                "(?<!^)" +
                "(" +
                " [A-Z][a-z] |" +
                " (?<=[a-z])[A-Z] | " +
                " (?<![A-Z])[A-Z]$" +
                ")",
                " $1", RegexOptions.IgnorePatternWhitespace);
        }
    }
}