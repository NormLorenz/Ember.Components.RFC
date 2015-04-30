using HTMLBarsHelper;
using System.Web;
using System.Web.Optimization;

namespace Ember.Components.RFC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/templates", new HTMLBarsTransformer())
               .IncludeDirectory("~/Scripts/app/templates", "*.hbs", true)
            );

            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/app/app.js")
                .IncludeDirectory("~/Scripts/app/components/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/controllers/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/helpers/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/models/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/routes/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/store/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/views/", "*.js", true)
            );

        }
    }
}
