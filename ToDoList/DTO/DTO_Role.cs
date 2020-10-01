using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class DTO_Role
    {
        private int roleID;
        private int roleName;

        public DTO_Role(int roleID, int roleName)
        {
            this.RoleID = roleID;
            this.RoleName = roleName;
        }
        public DTO_Role ()
        {
        }
        public int RoleID { get => roleID; set => roleID = value; }
        public int RoleName { get => roleName; set => roleName = value; }
    }
}
