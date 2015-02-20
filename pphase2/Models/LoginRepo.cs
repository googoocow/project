using PhaseTwo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhaseTwo.Models
{

    public enum UserType{ Invalid, Admin, Contractor, User }

    public class LoginRepo
    {
        PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

        public static UserType GetUserType(Login model)
        {
            if (LoginRepo.IsValid(model)) return UserType.Invalid;

            string username = model.UserName;

            if (AdminRepo.UserNameExists(username))		 return UserType.Admin;
            if (UserRepo.UserNameExists(username))		 return UserType.User;
            if (ContractorRepo.UserNameExists(username)) return UserType.Contractor;

            return UserType.Invalid;
        }
		public static bool IsValid(Login model)
        {
			if (model.UserName == null || model.UserName == "") return false;
            if (model.Password == null || model.Password == "") return false;

            return true;
        }
    }
}