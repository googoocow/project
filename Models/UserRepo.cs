using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhaseTwo.Models
{
    public class UserRepo
    {
        static PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

        public static bool UserNameExists(string username)
        {
            return (ctx.Users.Where(a => a.username == username).Count() == 1);
        }
        public static IEnumerable<User> GetAllUsers()
        {
            return new PhaseTwoDBEntities().Users.ToList();
        }
    }
}