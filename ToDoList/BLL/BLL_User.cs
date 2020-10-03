using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BLL_User
    {
        DAL_User dAL_User = new DAL_User();
        public int getRoleIDByEmail(string email)
        {
            return dAL_User.getRoleIDByEmail(email);
        }
    }
}
