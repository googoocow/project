using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhaseTwo.Models
{
    public class AllTablesRepo
    {
        PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

        public bool UserNameExists(string username)
        {
            return 
                (
                    ctx.Admins.Where(a => a.username == username).Count() == 1 ||
                    ctx.Contractors.Where(a => a.username == username).Count() == 1 ||
                    ctx.Users.Where(a => a.username == username).Count() == 1
                );
        }
    }
}