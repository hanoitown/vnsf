using System.Web;
using System.Web.Optimization;

namespace Vnsf.WebHost
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/appjs")
                    .IncludeDirectory("~/Scripts/app", "*.js", searchSubdirectories: false)
                    .IncludeDirectory("~/Scripts/utilities", "*.js", searchSubdirectories: false));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                    "~/Scripts/bootstrap.js",
                                    "~/Scripts/respond.js"));

            //bundle third party libs
            bundles.Add(new ScriptBundle("~/bundles/extlibs").Include(
                        "~/Scripts/json2.js", // IE7 needs this

                        // jQuery plugins
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",


                        // Knockout and its plugins
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.mapping-latest.js",
                        "~/Scripts/knockout.validation.js",

                        // Other 3rd party libraries
                        "~/Scripts/underscore.js",
                        "~/Scripts/moment.js",

                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/tinymce/tinymce.js",
                //"~/Scripts/jquery.fileupload.js",
                //"~/Scripts/jquery.iframe-transport.js",
                        "~/Scripts/selectize.js"

                        //"~/Scripts/jasny-bootstrap.js"

                        ));


            //custom LESS files
            //bundles.Add(new Bundle("~/Content/less", new LessTranform(), new CssMinify()).Include(
            //            "~/Content/toastr.less",
            //            "~/Content/styles.less"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                //"~/Content/jquery.fileupload-ui-noscript.css",
                //"~/Content/jquery.fileupload-ui.css",
                      "~/Content/datepicker3.css",
                      "~/Content/selectize.bootstrap3.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
