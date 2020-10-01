using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class role
    {
        private int roleID;
        private int roleName;

        public role(int roleID, int roleName)
        {
            this.RoleID = roleID;
            this.RoleName = roleName;
        }
        public role ()
        {
        }
        public int RoleID { get => roleID; set => roleID = value; }
        public int RoleName { get => roleName; set => roleName = value; }
    }
}
