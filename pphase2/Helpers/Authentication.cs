using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PhaseTwo.Helpers
{
	public static class AuthenticationHelper
	{
		public static MvcHtmlString If(this MvcHtmlString value, bool eval) { 
			return eval ? value : MvcHtmlString.Empty;
		}
	}
}