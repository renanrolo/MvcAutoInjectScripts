using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.IO;

namespace System.Web.Mvc
{
    public class BaseController : Controller
    {
        protected new internal ViewResult View()
        {
            string path = "";

            foreach (var item in ControllerContext.RouteData.Values)
            {
                path = String.Format("{0}{1}", path, item.Value);
            }

            string bundlePath = String.Format("~/bundles/Views{0}", path);

            var bundleExists = System.Web.Optimization.BundleTable.Bundles.Any( x =>  x.Path == bundlePath);

            if (bundleExists)
            {
                ViewBag.scriptViewBundle = bundlePath;
            }

            return base.View();

            //if (!IsMobile()) return base.View();

            //var viewName = ControllerContext.RouteData.GetRequiredString("action");
            //CheckForMobileEquivalentView(ref viewName, ControllerContext);

            //return base.View(viewName, (object)null);
        }

        protected new internal ViewResult View(object model)
        {
            return base.View(model);

            //if (!IsMobile()) return base.View(model);
            //
            //var viewName = ControllerContext.RouteData.GetRequiredString("action");
            //CheckForMobileEquivalentView(ref viewName, ControllerContext);
            //
            //return base.View(viewName, model);
        }

        protected new internal ViewResult View(string viewName)
        {
            return base.View(viewName);

            //if (!IsMobile()) return base.View(viewName);
            //
            //CheckForMobileEquivalentView(ref viewName, ControllerContext);
            //return base.View(viewName);
        }

        protected new internal ViewResult View(string viewName, object model)
        {
            return base.View(viewName, model);
                
            //if (!IsMobile()) return base.View(viewName, model);
            //
            //CheckForMobileEquivalentView(ref viewName, ControllerContext);
            //return base.View(viewName, model);
        }

        // Need this to prevent View(string, object) stealing calls to View(string, string)
        protected new internal ViewResult View(string viewName, string masterName)
        {
            return base.View(viewName, masterName);
        }
    }
}