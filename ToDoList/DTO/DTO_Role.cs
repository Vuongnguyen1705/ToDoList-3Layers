using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Role
    {
        public DTO_Role()
        {
        }

        public DTO_Role(int roleID, int roleName)
        {
            RoleID = roleID;
            RoleName = roleName;
        }

        public int RoleID { get; set; }
        public int RoleName { get; set; }
    }
}
