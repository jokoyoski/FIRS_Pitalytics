using System.Web;
using System.Web.Optimization;

namespace Pitalytics
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*", "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                                  "~/Scripts/script-custom-validator.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     
                       "~/Content/asset/css/bootstrap.min.css",
                     
                      "~/Content/datatables.css",
                      "~/Content/newSite.css",
                      "~/Content/site.css"));







            bundles.Add(new StyleBundle("~/Content/Styles").Include(

                     "~/Content/bootstrap.min.css",

                    "~/Content/datatables.css",
                    "~/Content/newSite.css",
                   
                    "~/Content/site.css"));








            bundles.Add(new StyleBundle("~/Content/css/style").Include(
            "~/Content/asset/css/bootstrap.min.css",
            "~/Content/asset/css/font-awesome.min.css",
            "~/Content/asset/css/owl.carousel.css",
            "~/Content/asset/css/owl.theme.css",
            "~/Content/asset/css/owl.transitions.css",
            "~/Content/asset/css/meanmenu/meanmenu.min.css",
            "~/Content/asset/css/animate.css",
            "~/Content/asset/css/normalize.css",
            "~/Content/asset/css/wave/waves.min.css",
            "~/Content/asset/css/wave/button.css",
            "~/Content/asset/css/scrollbar/jquery.mCustomScrollbar.min.css",
            "~/Content/asset/css/notika-custom-icon.css",
           
            "~/Content/asset/css/main.css",
          "~/Content/asset/css/newSite.css",
            "~/Content/asset/css/responsive.css"

            ));


            bundles.Add(new ScriptBundle("~/Scripts/js/script").Include(
              "~/Scripts/vendor/modernizr-2.8.3.min.js",
                "~/Scripts/vendor/jquery-1.12.4.min.js",
               "~/Scripts/bootstrap.min.js",
               "~/Scripts/wow.min.js",
               "~/Scripts/jquery-price-slider.js",
               "~/Scripts/owl.carousel.min.js",
               "~/Scripts/jquery.scrollUp.min.js",
               "~/Scripts/meanmenu/jquery.meanmenu.js",
               "~/Scripts/counterup/jquery.counterup.min.js",
               "~/Scripts/counterup/waypoints.min.js",
               "~/Scripts/counterup/counterup-active.js",
               "~/Scripts/scrollbar/jquery.mCustomScrollbar.concat.min.js",
               "~/Scripts/sparkline/jquery.sparkline.min.js",
               "~/Scripts/sparkline/sparkline-active.js",
               "~/Scripts/flot/jquery.flot.js",
               "~/Scripts/flot/jquery.flot.resize.js",
               "~/Scripts/flot/flot-active.js",
               "~/Scripts/knob/jquery.knob.js",
               "~/Scripts/knob/jquery.appear.js",
               "~/Scripts/knob/knob-active.js",
               "~/Scripts/wave/wave-active.js",

               "~/Scripts/plugins.js",
              
               "~/Scripts/main.js",
               "~/Scripts/jquery.unobtrusive-ajax.min.js",
               "~/Scripts/jquery.validate.unobtrusive.min.js"
            ));
        }
    }
}
