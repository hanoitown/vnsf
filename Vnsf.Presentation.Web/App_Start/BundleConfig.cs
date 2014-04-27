using System.Web;
using System.Web.Optimization;

namespace Vnsf.Presentation.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));

            //bundle third party libs
            bundles.Add(new ScriptBundle("~/bundles/extlibs").Include(
                        "~/Scripts/lib/json2.js", // IE7 needs this

                        // jQuery plugins
                        "~/Scripts/lib/jquery-ui-{version}.js", 
                        "~/Scripts/lib/jquery.unobtrusive-ajax.js",
                        "~/Scripts/lib/jquery.validate.js",

                        // Knockout and its plugins
                        "~/Scripts/lib/knockout-{version}.js",
                        "~/Scripts/lib/knockout.mapping-latest.js",
                        "~/Scripts/lib/knockout.validation.js",

                        // Other 3rd party libraries
                        "~/Scripts/lib/bootstrap.js",
                        "~/Scripts/lib/underscore.js",
                        "~/Scripts/lib/moment.js",
                        "~/Scripts/lib/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/appjs")
                    .IncludeDirectory("~/Scripts/app", "*.js", searchSubdirectories: false));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/bootstrap/bootstrap.css",
                        "~/Content/bootstrap/bootstrap-theme.css",
                        "~/Content/fontawesome/font-awesome.css"));

            //3rd party css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                            "~/Content/site.css",
                            "~/Content/bootstrap/bootstrap.css",
                            "~/Content/bootstrap/bootstrap-theme.css",
                            "~/Content/fontawesome/font-awesome.css")
                            .IncludeDirectory("~/Content/themes/base/", "*.css", false));


            //custom LESS files
            bundles.Add(new Bundle("~/Content/less", new LessTranform(), new CssMinify()).Include(
                        "~/Content/toastr.less",
                        "~/Content/styles.less"));
        }
    }
}