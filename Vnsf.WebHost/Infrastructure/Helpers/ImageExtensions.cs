using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Infrastructure.Helpers
{
    public static class ImageExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageRelativeUrl);
        public static TagBuilder Image(string imageUrl, string alt, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Image(this HtmlHelper helper, string imageRelativeUrl, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Image(this HtmlHelper helper, string imageRelativeUrl, object htmlAttributes);
        public static MvcHtmlString Image(this HtmlHelper helper, string imageRelativeUrl, string alt);
        public static MvcHtmlString Image(this HtmlHelper helper, string imageRelativeUrl, string alt, IDictionary<string, object> htmlAttributes);
        public static MvcHtmlString Image(this HtmlHelper helper, string imageRelativeUrl, string alt, object htmlAttributes);
    }
}