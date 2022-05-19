﻿using System.Web;
using System.Web.Optimization;

namespace Cotizador
{
    public class BundleConfig
    {        
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                      
                      "~/Content/css/site.css"));
        }
    }
}
