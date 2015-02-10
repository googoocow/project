using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PhaseTwo.Models
{
    public class AdminRepo
    {

        public static bool UserNameExists(string username)
        {
            return (new PhaseTwoDBEntities().Admins.Where(a => a.username == username).Count() == 1);
        }
		
		//Could convert to generic
		public static void AddAdmin(Admin admin) {
			var ctx = new PhaseTwoDBEntities();
			ctx.Admins.Add(admin);
			ctx.SaveChanges();
		}
    }
}