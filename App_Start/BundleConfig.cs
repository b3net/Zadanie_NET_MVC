using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-3.7.1.min.js"));

            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/jquery.validate.min.js",
                        "~/Content/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap-js").Include(
                      "~/Content/Bootstrap/bootstrap.bundle.min.js"));

            bundles.Add(new Bundle("~/Content/bootstrap-css").Include(
                      "~/Content/Bootstrap/bootstrap.min.css"));
            
            bundles.Add(new StyleBundle("~/Content/bootstrap-icons").Include(
                      "~/Content/Bootstrap/bootstrap-icons.css"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/Styles/styles.css"));
        }
    }
}
