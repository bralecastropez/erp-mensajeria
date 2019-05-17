using System.Web;
using System.Web.Optimization;

namespace ERP_Mensajeria
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      /*"~/Scripts/bootstrap.js",*/
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/resources/css/bootstrap.min.css",
                "~/Content/resources/css/mdb.min.css", 
                "~/Content/resources/css/style.css",
                "~/Content/resources/font/font-awesome/all.min.css"));

            bundles.Add(new StyleBundle("~/bundles/jsmaterial").Include(
                "~/Content/resources/js/popper.min.js",
                "~/Content/resources/js/bootstrap.min.js",
                "~/Content/resources/js/mdb.min.js"));

        }
    }
}
