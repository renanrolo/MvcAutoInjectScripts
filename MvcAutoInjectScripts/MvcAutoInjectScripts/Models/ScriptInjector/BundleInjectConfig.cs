using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace System.Web.Optimization
{
    public class BundleInjectConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            foreach (var item in allPathFiles())
            {
                bundles.Add(new ScriptBundle(item.Key).Include(item.Value));
            }
        }



        private static Dictionary<string, string> allPathFiles()
        {
            Dictionary<string, string> urls = new Dictionary<string, string>();

            var serverPath = HostingEnvironment.ApplicationPhysicalPath;

            foreach (var item in Directory.EnumerateFiles(serverPath, "*.js", SearchOption.AllDirectories))
            {
                string viewPath = item.Replace(".js", ".cshtml");
                if (File.Exists(viewPath))
                {
                    var itemWithoutRoot = item.Replace(serverPath, "").Replace("\\", "/");
                    string bundlePath = String.Format("~/bundles/{0}", itemWithoutRoot.Replace(".js", "").Replace("/", ""));
                    string jsPath = String.Format("~/{0}", itemWithoutRoot);
                    urls.Add(bundlePath, jsPath);
                }
            }
          
            return urls;
        }
    }
}