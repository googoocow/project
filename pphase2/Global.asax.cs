using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PhaseTwo.Models;
using System.Security.Principal;
using System.Threading;
namespace PhaseTwo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
        }
		void Application_PostAuthenticateRequest()
		{
			if (User.Identity.IsAuthenticated)
			{
				var name = User.Identity.Name; // Get current user name.

				PhaseTwoDBEntities context = new PhaseTwoDBEntities();
				var user = context.AspNetUsers.Where(u => u.UserName == name).FirstOrDefault();
				IQueryable<string> roleQuery = from u in context.AspNetUsers
											   from r in u.AspNetRoles
											   where u.UserName == Context.User.Identity.Name
											   select r.Name;
				string[] roles = roleQuery.ToArray();

				HttpContext.Current.User = Thread.CurrentPrincipal =
										   new GenericPrincipal(User.Identity, roles);
			}
		}

    }
}
