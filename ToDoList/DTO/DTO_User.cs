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

        public DTO_User(int userID, string userFullName, string userPhoneNumber, string userEmail, string userpassWord, string userAddress, long userBirthday, string userGender, int userRole)
        {
            UserID = userID;
            UserFullName = userFullName;
            UserPhoneNumber = userPhoneNumber;
            UserEmail = userEmail;
            UserpassWord = userpassWord;
            UserAddress = userAddress;
            UserBirthday = userBirthday;
            UserGender = userGender;
            UserRole = userRole;
        }

        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserpassWord { get; set; }
        public string UserAddress { get; set; }
        public long UserBirthday { get; set; }
        public string UserGender { get; set; }
        public int UserRole { get; set; }
    }
}
