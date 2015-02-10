using System;
using System.Collections.Generic;
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
        public static IEnumerable<Admin> GetAllAdmins()
        {
            return new PhaseTwoDBEntities().Admins.ToList();
        }
    }
}