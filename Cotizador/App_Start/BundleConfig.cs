using System.Web;
using System.Web.Optimization;

namespace Cotizador
{
    public class BundleConfig
    {        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/comunes").Include(
                      "~/Scripts/comunes/comunes.js",
                      "~/Scripts/plugins/jquery.mask.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                      
                      "~/Content/css/site.css"));
        }
    }
}
