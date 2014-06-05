using System.Web;
using System.Web.Optimization;

namespace PTO.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*")
            );

            //bundles.UseCdn = true;
            //bundles.Add(new ScriptBundle("~/bundles/googlemaps", "http://maps.googleapis.com/maps/api/js?sensor=false"));
                //.Include(string.Format("http://maps.googleapis.com/maps/api/js?key={0}&sensor=false", ""))

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/lodash.js",
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*",
                    //"~/Scripts/gridmvc.js",
                    "~/Scripts/bootstrap*",
                    "~/Scripts/maps/markerclusterer.js",

                    "~/Scripts/app/app.core.js",
                    "~/Scripts/app/app.admin.js",
                    "~/Scripts/app/app.maps.js",

                    "~/Scripts/app/util.js"
                )
            );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                    "~/Content/bootstrap/bootstrap.css",
                    "~/Content/Gridmvc.css",
                    "~/Content/app/app.css"
                )
            );
        }
    }
}