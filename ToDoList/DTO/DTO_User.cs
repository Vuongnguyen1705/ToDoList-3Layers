using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace DTO
{
    public class DTO_User
    {
        private int userID;
        private string userFullName;
        private string userPhoneNumber;
        private string userEmail;
        private string userpassWord;
        private string userAddress;
        private DateTime userBirthDate;
        private string userGender;
        private int userRole;

        public int UserID { get => userID; set => userID = value; }
        public string UserFullName { get => userFullName; set => userFullName = value; }
        public string UserPhoneNumber { get => userPhoneNumber; set => userPhoneNumber = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserpassWord { get => userpassWord; set => userpassWord = value; }
        public string UserAddress { get => userAddress; set => userAddress = value; }
        public DateTime UserBirthDate { get => userBirthDate; set => userBirthDate = value; }
        public string UserGender { get => userGender; set => userGender = value; }
        public int UserRole { get => userRole; set => userRole = value; }
        public DTO_User()
        {
        }

        public DTO_User(int userID, string userFullName, string userPhoneNumber, string userEmail, string userpassWord, string userAddress, DateTime userBirthDate, string userGender, int userRole)
        {
            this.userID = userID;
            this.userFullName = userFullName;
            this.userPhoneNumber = userPhoneNumber;
            this.userEmail = userEmail;
            this.userpassWord = userpassWord;
            this.userAddress = userAddress;
            this.userBirthDate = userBirthDate;
            this.userGender = userGender;
            this.userRole = userRole;
        }

        //nhieu do
        //ctrl . or alt enter
        //tạo cóntructer


        //tạo get set

        //Ctrl R E
    }
}
