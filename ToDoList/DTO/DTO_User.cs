using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace DTO
{
    public class DTO_User
    {
        public DTO_User()
        {
        }

        public DTO_User(int userID, string userAvatar, string userFullName, string userPhoneNumber, string userEmail, string userPassword, string userAddress, DateTime userBirthday, string userGender, bool userIsEnable, string userRoleID)
        {
            UserID = userID;
            UserAvatar = userAvatar;
            UserFullName = userFullName;
            UserPhoneNumber = userPhoneNumber;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserAddress = userAddress;
            UserBirthday = userBirthday;
            UserGender = userGender;
            UserIsEnable = userIsEnable;
            UserRoleID = userRoleID;
        }

        public int UserID { get; set; }
        public string UserAvatar { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public DateTime UserBirthday { get; set; }
        public string UserGender { get; set; }
        public bool UserIsEnable { get; set; }
        public string UserRoleID { get; set; }
    }
}
