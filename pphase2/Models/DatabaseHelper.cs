using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhaseTwo.Models
{
	public class DatabaseHelper
	{
		public static IEnumerable<T> GetAll<T>() where T : class
		{
			System.Data.Entity.DbSet<T> data;
			PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

			switch (typeof(T).Name)
			{
				case "Admin":		data =	(System.Data.Entity.DbSet<T>) (object) ctx.Admins;		break;
				case "Contractor":  data =	(System.Data.Entity.DbSet<T>) (object) ctx.Contractors;	break;
				case "User":		data =	(System.Data.Entity.DbSet<T>) (object) ctx.Users;		break;
				default: return null;
			}

			return data.ToList();
		}
	}
}