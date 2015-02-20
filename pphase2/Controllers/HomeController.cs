using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhaseTwo.Controllers
{
    public class HomeController : Controller
    {
		[Authorize(Roles="admin")]
		[AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
		public ActionResult NotLoggedInIndex()
        {
            ViewBag.Title = "Please Log In";
            return View();
        }
    }
}
