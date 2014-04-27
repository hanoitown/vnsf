using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Web.Mvc.Html;

namespace Vnsf.WebHost.Helpers
{
    public static class BootstrapHelpers
    {
        public static IHtmlString BootStrapLabelFor<TModel, TProp>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProp>> property)
        {
            return helper.LabelFor(property, new
            {
                @class = "col-md-2 control-label"
            });
        }

        public static IHtmlString BootStrapLabelFor(this HtmlHelper helper, string property)
        {
            return helper.Label(property, new
            {
                @class = "col-md-2 control-label"
            });

        }
        public static MvcForm BeginHorizontalForm<TController>(this HtmlHelper helper, Expression<Action<TController>> action) where TController : Controller
        {
            return helper.BeginForm<TController>(action, FormMethod.Post, new { @class = "form-horizontal" });
        }
    }
}