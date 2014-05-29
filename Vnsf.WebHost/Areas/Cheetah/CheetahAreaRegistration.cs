using System.Web.Mvc;

namespace Vnsf.WebHost.Areas.Cheetah
{
    public class CheetahAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cheetah";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Directory",
                "Cheetah/{controller}/{action}/{*location}",
                new { Controller="Document", action = "Index", Location = UrlParameter.Optional },
                new[] { "Vnsf.WebHost.Areas.Cheetah.Controllers" }
            );

            //context.MapRoute(
            //    "Folder",
            //    "Cheetah/{controller}/{action}/{folder}/{id}",
            //    new { controller = "Document", action = "FolderView", id = UrlParameter.Optional },
            //    new[] { "Vnsf.WebHost.Areas.Cheetah.Controllers" }
            //);

            context.MapRoute(
                "Cheetah_default",
                "Cheetah/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Vnsf.WebHost.Areas.Cheetah.Controllers" }
            );


        }
    }
}