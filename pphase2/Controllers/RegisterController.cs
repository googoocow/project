using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PhaseTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhaseTwo.Controllers
{
    public class RegisterController : Controller
    {
		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(Admin newUser)
		{
			var userStore = new UserStore<IdentityUser>();
			var manager = new UserManager<IdentityUser>(userStore);
			var identityUser = new IdentityUser()
			{
				UserName = newUser.username,
				Email = newUser.email
			};
			IdentityResult result = manager.Create(identityUser, newUser.password);

			if (result.Succeeded)
			{
				var authenticationManager
								  = HttpContext.Request.GetOwinContext().Authentication;
				var userIdentity = manager.CreateIdentity(identityUser,
										   DefaultAuthenticationTypes.ApplicationCookie);
				authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
			}
			return View();
		}

    }
}