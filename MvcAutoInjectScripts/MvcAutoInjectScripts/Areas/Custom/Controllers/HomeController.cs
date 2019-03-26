using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAutoInjectScripts.Areas.Custom.Controllers
{
    public class HomeController : ScriptInjectorController
    {
        // GET: Custom/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}