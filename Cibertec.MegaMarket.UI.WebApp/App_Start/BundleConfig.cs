using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;


namespace Cibertec.MegaMarket.UI.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            ///////
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            // Scripts jQuery DataTables
            var ScriptDataTables = new ScriptBundle("~/DataTables/js").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/DataTables/dataTables.responsive.min.js",
                "~/Scripts/DataTables/responsive.bootstrap.min.js",
                "~/Scripts/DataTables/dataTables.language.es.js");
            ScriptDataTables.Orderer = new PassthruBundleOrderer();
            bundles.Add(ScriptDataTables);

            // Scripts Validación de Formularios
            var ScriptForm = new ScriptBundle("~/bundles/forms").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/general.js");
            ScriptForm.Orderer = new PassthruBundleOrderer();
            bundles.Add(ScriptForm);

            // Scripts Base para el Funcionamiento del Módulo
            var ScriptBase = new ScriptBundle("~/bundles/base").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/eflexis.dialog.js",
                "~/Scripts/jquery.eflexis.dialog.js",
                "~/Scripts/jquery.icheck.min.js",
                "~/Scripts/jquery-ui-1.12.0.min.js",
                "~/Scripts/jquery-ui-extend.js",
                "~/Scripts/Site.js");
            ScriptBase.Orderer = new PassthruBundleOrderer();
            bundles.Add(ScriptBase);

            // Styles jQuery DataTables
            var StyleDataTables = new StyleBundle("~/Content/DataTables/base").Include(
                "~/Content/DataTables/base.css");
            StyleDataTables.Orderer = new PassthruBundleOrderer();
            bundles.Add(StyleDataTables);

            // Style Base para el Funcionamiento del Módulo
            var StyleBase = new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/jquery-ui.min.css",
                "~/Content/jquery-ui-1.10.0.custom.css",
                "~/Content/font-awesome.min.css",
                "~/Content/iCheck/all.css",
                "~/Content/Site.css");
            StyleBase.Orderer = new PassthruBundleOrderer();
            bundles.Add(StyleBase);


        }

        class PassthruBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }
        }
    }
}
