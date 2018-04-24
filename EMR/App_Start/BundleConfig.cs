using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EMR.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/vendor/font-awesome/css/font-awesome.css",
                "~/Content/vendor/simple-line-icons/css/simple-line-icons.css",
                "~/Content/bootstrap.css",
                "~/Content/css/app.css",
                "~/Content/vendor/animate.css/animate.css",
                "~/Content/vendor/whirl/dist/whirl.css"
                ));


            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                       "~/Content/vendor/modernizr/modernizr.custom.js",
                       "~/Content/vendor/jquery/dist/jquery.js",
                       "~/Content/vendor/bootstrap/dist/js/bootstrap.js",
                       "~/Content/vendor/js-storage/js.storage.js",
                       "~/Content/vendor/parsleyjs/dist/parsley.js",
                       "~/Content/js/app.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jsMain").Include(
            "~/Content/vendor/modernizr/modernizr.custom.js",
            "~/Content/vendor/jquery/dist/jquery.js",
            //"~/Scripts/jquery.jquery-1.10.2.min.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.unobtrusive-ajax.js",
            "~/Scripts/jquery.validate.unobtrusive.js",
            "~/Content/vendor/bootstrap/dist/js/bootstrap.js",
            "~/Content/vendor/js-storage/js.storage.js",
            "~/Content/vendor/parsleyjs/dist/parsley.js",
            "~/Content/vendor/popper.js/dist/umd/popper.js",
            "~/Content/vendor/popper.js/dist/umd/popper.js",
            "~/Content/vendor/bootstrap/dist/js/bootstrap.js",
            "~/Content/vendor/jquery.easing/jquery.easing.js",
            "~/Content/vendor/animo/animo.js",
            "~/Content/vendor/screenfull/dist/screenfull.js",
             "~/Content/js/app.js"
           ));
        }
    }
}