using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhaseTwo.Models
{
    public class ContractorRepo
    {
        static PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

        public static bool UserNameExists(string username)
        {
            return (ctx.Contractors.Where(a => a.username == username).Count() == 1);
        }
        public static IEnumerable<Contractor> GetAllContractors()
        {
			return new PhaseTwoDBEntities().Contractors.ToList();
        }
    }
}