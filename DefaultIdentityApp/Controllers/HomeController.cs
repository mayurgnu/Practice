using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultIdentityApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MyLayoutChild1()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Scss()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}