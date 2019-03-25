using MvcAutoInjectScripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAutoInjectScripts.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var viewModel = new SimpleViewModel
            {
                MyName = "Darkness",
                MyThoughts = "Hello darkness my old friend!"
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult About(SimpleViewModel viewModel)
        {
            ViewBag.Message = "Your application description page.";

            return View(viewModel);
        }

        public ActionResult AboutCopy()
        {
            ViewBag.Message = "Your application description page.";

            var viewModel = new SimpleViewModel
            {
                MyName = "About",
                MyThoughts = "This Action references About cshtml file"
            };

            return View("About", viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "I don't have js with me right now...";
            return View();
        }
    }
}