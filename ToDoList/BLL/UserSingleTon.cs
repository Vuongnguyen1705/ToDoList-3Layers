using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserSingleTon
    {
        private static readonly UserSingleTon instance = new UserSingleTon();
        private DTO_User user;
        static UserSingleTon()
        {
        }
        private UserSingleTon()
        {
            User = new DTO_User();
        }
        public static UserSingleTon Instance
        {
            get
            {
                return instance;
            }
        }

        public DTO_User User { get; set; }
    }
}
