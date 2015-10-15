using System.Web;
using System.Web.Optimization;

namespace CivicHackApiLocator.WebApi
{
    /// <summary>
    /// Bundling configuration
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers bundles with the bundling system
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendorjs").Include(
                        "~/bower_components/jquery/dist/jquery.js",
                        "~/bower_components/bootstrap/dist/js/bootstrap.js",
                        "~/bower_components/angular/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/appjs").IncludeDirectory("~/Scripts", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/vendorcss").Include(
                      "~/bower_components/bootstrap/dist/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/appcss").IncludeDirectory("~/Content", "*.css", true));
        }
    }
}
