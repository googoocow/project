using PhaseTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhaseTwo.Controllers
{
    public class RoleController : Controller
    {
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(AspNetRole role)
		{
			PhaseTwoDBEntities context = new PhaseTwoDBEntities();
			context.AspNetRoles.Add(role);
			context.SaveChanges();
			return View();
		}

    }
}