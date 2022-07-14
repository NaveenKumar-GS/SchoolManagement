using System.Web;
using System.Web.Optimization;

namespace Schoolmanagementn
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

             bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*"));

             // Use the development version of Modernizr to develop with and learn from. Then, when you're
             // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                         "~/Scripts/modernizr-*"));

             bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"));

             bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css"));
 */
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                      "~/assets/plugins/global/plugins.bundle.js",
                      "~/assets/plugins/custom/prismjs/prismjs.bundle.js",
                      "~/assets/js/scripts.bundle.js",
                      "~/assets/plugins/custom/datatables/datatables.bundle.js",
                      "~/assets/js/pages/crud/datatables/data-sources/ajax-server-side.js",
                      "~/assets/js/pages/features/miscellaneous/treeview.js",
                      "~/assets/plugins/custom/jstree/jstree.bundle.js",
                      "~/assets/plugins/custom/fullcalendar/fullcalendar.bundle.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/keenthemesjs").Include(
                        "~/assets/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax").Include(
                        "~/Scripts/jquery.unobtrusive*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // jquery datataables js files
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/DataTables/*.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/plugins/custom/datatables/datatables.bundle.css",
                      "~/assets/plugins/global/plugins.bundle.css",
                      "~/assets/plugins/custom/prismjs/prismjs.bundle.css",
                      "~/assets/css/style.bundle.css",
                      "~/assets/css/themes/layout/header/base/light.css",
                      "~/assets/css/themes/layout/header/menu/light.css",
                      "~/assets/css/themes/layout/brand/dark.css",
                      "~/assets/css/themes/layout/aside/dark.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/keenthemescss").Include(
                        "~/assets/*.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // jquery datatables css file
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.css"));

            BundleTable.EnableOptimizations = true;


        }
    }
}
