using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PhaseTwo.Models;
using PhaseTwo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PhaseTwo.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(Login login)
		{
			IdentityUser identityUser = new UserManager<IdentityUser>(new UserStore<IdentityUser>()).Find(login.UserName, login.Password);

			if (ModelState.IsValid)
			{
				if (identityUser != null)
				{
					IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
					authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

					var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.UserName), }, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);
					authenticationManager.SignIn(new AuthenticationProperties{ IsPersistent = false }, identity);
					
					//route to proper page
					if (LoginRepo.GetUserType(login) == UserType.Admin) return RedirectToAction("Index", "Home");
					else												return RedirectToAction("Index", "Home");

				}
			}

			return View();
		}

	}
}