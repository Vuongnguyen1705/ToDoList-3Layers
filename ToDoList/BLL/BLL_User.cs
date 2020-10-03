using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO;

namespace BLL
{
    public class BLL_User
    {
        DAL_User dAL_User = new DAL_User();
        public int getRoleIDByEmail(string email)
        {
            return dAL_User.getRoleIDByEmail(email);
        }


		public void AddUser(DTO_User u)
		{
			dAL_User.AddUser(u);
		}

		public void UpdateUser(DTO_User u)
		{
			dAL_User.UpdateUser(u);
		}

		public void DeleteUser(int UserID)
		{
			dAL_User.DeleteUser(UserID);
		}
	}
}
