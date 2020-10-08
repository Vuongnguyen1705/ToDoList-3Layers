﻿using DAL;
using DTO;
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

        public List<DTO_User> getUserEnable()
        {
            return dAL_User.getUserEnable();
        }
        public DTO_User getUserByID(int idUser)
        {
            return dAL_User.getUserByID(idUser);
        }
        public int getRoleIDByEmail(string email)
        {
            return dAL_User.getRoleIDByEmail(email);
        }

        public string getFullNameByID(int idUser)
        {
            return dAL_User.getFullNameByID(idUser);
        }
        public List<string> getFullName()
        {
            return dAL_User.getFullName();
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
	

        public DTO_User getUserByEmail(string email)
        {
            return dAL_User.getUserByEmail(email);
        }

        public int getIDByFullName(string name)
        {
            return dAL_User.getIDByFullName(name);
        }
    }

}
