using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BLL_User
    {
        DAL_User dAL_User = new DAL_User();

        public List<DTO_User> getAll()
        {
            return dAL_User.getAll();
        }
        public int getRoleIDByEmail(string email)
        {
            return dAL_User.getRoleIDByEmail(email);
        }
        public DTO_User getUserByEmail(string email)
        {
            return dAL_User.getUserByEmail(email);
        }
    }
}
