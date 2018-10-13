using System.Web;
using System.Web.Optimization;
using TeduShop.Common;

namespace TeduShop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           // bundles.Add(new ScriptBundle("~/js/jquery").Include(
           //                   "~/Assets/client/js/jquery.min.js"
           //     ));
           //bundles.Add(new ScriptBundle("~/js/plugins").Include(
           //     "~/Assets/client/js/scripts.js",
           //       "~/Assets/client/js/move-top.js",
           //         "~/Assets/client/js/easing.js",
           //           "~/Assets/client/js/jquery.flexisel.js",
           //             "~/Assets/client/js/common.js",
           //                   "~/Assets/client/js/jquery.easydropdown.js"
           //     ));
           // bundles.Add(new StyleBundle("~/css/base")
           //     .Include("~/Assets/client/css/bootstrap.css", new CssRewriteUrlTransform())
           //      .Include("~/Assets/client/css/style.css", new CssRewriteUrlTransform())
           //       .Include("~/Assets/client/css/nav.css", new CssRewriteUrlTransform())
           //       );
          BundleTable.EnableOptimizations = bool.Parse(ConfigHelper.GetByKey("EnableBundles"));

        }
    }
}
