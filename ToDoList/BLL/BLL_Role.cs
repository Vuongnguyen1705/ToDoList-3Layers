using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BLL_Role
    {
        DAL_Role role = new DAL_Role();
        public string getRoleNameByID(int idRole)
        {
            return role.getRoleNameByID(idRole);
        }
    }
}
