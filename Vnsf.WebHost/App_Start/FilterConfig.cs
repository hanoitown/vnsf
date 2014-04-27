using System.Web;
using System.Web.Mvc;
using Vnsf.WebHost.Filters;

namespace Vnsf.WebHost
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
