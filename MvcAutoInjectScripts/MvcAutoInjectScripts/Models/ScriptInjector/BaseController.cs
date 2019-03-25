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
            InjectJavascript();
            return base.View();
        }

        protected new internal ViewResult View(object model)
        {
            InjectJavascript();
            return base.View(model);
        }

        protected new internal ViewResult View(string viewName)
        {
            InjectJavascript(viewName);
            return base.View(viewName);
        }

        protected new internal ViewResult View(string viewName, object model)
        {
            InjectJavascript(viewName);
            return base.View(viewName, model);
        }

        protected new internal ViewResult View(string viewName, string masterName, object model)
        {
            InjectJavascript(viewName);
            return base.View(viewName, masterName, model);
        }

        // Need this to prevent View(string, object) stealing calls to View(string, string)
        protected new internal ViewResult View(string viewName, string masterName)
        {
            InjectJavascript(viewName);
            return base.View(viewName, masterName);
        }

        private void InjectJavascript(string action = null)
        {
            string _action = action ?? ControllerContext.RouteData.Values["action"].ToString();
            string _controller = ControllerContext.RouteData.Values["controller"].ToString();
            string bundlePath = String.Format("~/bundles/Views{0}{1}", _controller, _action);

            var bundleExists = System.Web.Optimization.BundleTable.Bundles.Any(x => x.Path == bundlePath);

            if (bundleExists)
            {
                ViewBag.scriptViewBundle = bundlePath;
            }
        }
    }
}