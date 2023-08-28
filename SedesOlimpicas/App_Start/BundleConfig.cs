using System.Web;
using System.Web.Optimization;

namespace SedesOlimpicas
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));

            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/sweetAlertStyles").Include(
                      "~/Content/sweetAlert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/sweetAlert").Include(
                      "~/Scripts/sweetAlert/sweetalert.min.js"));

            // dataPicker styles
            bundles.Add(new StyleBundle("~/datePickerStyles").Include(
                      "~/Content/dataPicker/datepicker.css"));

            // dataPicker 
            bundles.Add(new ScriptBundle("~/datePicker").Include(
                      "~/Scripts/datapicker/datepicker.js"));
            // jQueryUI CSS
            bundles.Add(new StyleBundle("~/jqueryuiStyles").Include(
                        "~/Scripts/jquery-ui/jquery-ui.min.css"));

            // jQueryUI 
            bundles.Add(new ScriptBundle("~/jquery-ui").Include(
                        "~/Scripts/jquery-ui/jquery-ui.min.js"));
        }
    }
}
