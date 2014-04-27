using System.Web.Optimization;

namespace Vnsf.Presentation.Web
{
    public class LessTranform:IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}