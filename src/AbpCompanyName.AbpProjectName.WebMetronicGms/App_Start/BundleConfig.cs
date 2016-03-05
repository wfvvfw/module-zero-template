using System.Collections.Generic;
using System.Web.Optimization;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms {
    public static class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.IgnoreList.Clear();

            #region Styles

            bundles.Add(
                new StyleBundle("~/Bundles/GLOBAL/css")
                        //http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all
                        .Include("~/Metronic/assets/global/plugins/googleapis/css/google-font.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/plugins/uniform/css/uniform.default.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css", new CssRewriteUrlTransform())
                 );

            bundles.Add(
                new StyleBundle("~/Bundles/GLOBAL/THEME/css")
                        .Include("~/Metronic/assets/global/css/components-md.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/css/plugins-md.min.css", new CssRewriteUrlTransform())
              );

            bundles.Add(
                new StyleBundle("~/Bundles/LAYOUT/THEME/css")
                        .Include("~/Metronic/assets/layouts/layout4/css/layout.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/layouts/layout4/css/themes/light.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/layouts/layout4/css/custom.min.css", new CssRewriteUrlTransform())
                );

            bundles.Add(
                new StyleBundle("~/Bundles/PAGE/css")
                        .Include("~/Metronic/assets/global/plugins/select2/css/select2.min.css", new CssRewriteUrlTransform())
                        .Include("~/Metronic/assets/global/plugins/select2/css/select2-bootstrap.min.css", new CssRewriteUrlTransform())
                );

            bundles.Add(
                new StyleBundle("~/Bundles/Abp/css")
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                );
            #endregion

            #region Script
            var globaljs =   new ScriptBundle("~/Bundles/GLOBAL/js")
                       .Include("~/Metronic/assets/global/plugins/jquery.min.js")
                       .Include("~/Metronic/assets/global/plugins/jquery-validation/js/jquery.validate.min.js")
                       .Include("~/Metronic/assets/global/plugins/jquery-validation/js/additional-methods.min.js")
                       .Include("~/Metronic/assets/global/plugins/js.cookie.min.js")
                       .Include("~/Metronic/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js")
                       .Include("~/Metronic/assets/global/plugins/jquery.blockui.min.js")
                       .Include("~/Metronic/assets/global/plugins/uniform/jquery.uniform.min.js")

                       .Include("~/Metronic/assets/global/plugins/bootstrap/js/bootstrap.min.js")
                       .Include("~/Metronic/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js")
                       .Include("~/Metronic/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js")

                       .Include("~/Metronic/assets/global/plugins/select2/js/select2.full.min.js")
                       .Include("~/Scripts/toastr.min.js")
                       .Include("~/Scripts/json2.min.js")
                       .Include("~/Scripts/moment-with-locales.min.js")
                       .Include("~/Scripts/others/spinjs/spin.js")
                       .Include("~/Scripts/sweetalert/sweet-alert.min.js")
                       .Include("~/Scripts/others/spinjs/spin.js")
                       .Include("~/Scripts/others/spinjs/jquery.spin.js")
                       .Include("~/Scripts/jquery.signalR-2.2.0.min.js")


                ;
            globaljs.Orderer = new AsIsBundleOrderer();
            bundles.Add(globaljs);

            

            bundles.Add(
               new ScriptBundle("~/Bundles/GLOBAL/THEME/js")
                    .Include("~/Metronic/assets/global/scripts/app.min.js")
                    .Include("~/Metronic/assets/layouts/layout4/scripts/layout.min.js")
                    .Include("~/Metronic/assets/layouts/layout4/scripts/demo.min.js")
                    .Include("~/Metronic/assets/layouts/global/scripts/quick-sidebar.min.js")
               );

            bundles.Add(
               new ScriptBundle("~/Bundles/Abp/js")
                        .Include("~/Abp/Framework/scripts/abp.js")
                         .Include("~/Abp/Framework/scripts/libs/abp.jquery.js")
                         .Include("~/Abp/Framework/scripts/libs/abp.toastr.js")
                         .Include("~/Abp/Framework/scripts/libs/abp.blockUI.js")
                         .Include("~/Abp/Framework/scripts/libs/abp.spin.js")
                         .Include("~/Abp/Framework/scripts/libs/abp.sweet-alert.js")


               );
            #endregion
        }
    }

    //js排序问题
    public class AsIsBundleOrderer : IBundleOrderer {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files) {
            return files;
        }

    }
}