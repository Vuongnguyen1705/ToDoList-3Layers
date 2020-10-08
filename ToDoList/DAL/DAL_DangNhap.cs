using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DAL_DangNhap
    {
        
        public bool TryLogin(string email, string password)
        {
            string query = @"Select * from [Users] where [U_Email] = '" + email + "' And [U_Password] = '" + password + "' and U_IsEnable=1";
            var _ = Connection.DoQuery(query);
            if (_.Rows.Count == 0)
                return false;
            var _username = _.Rows[0]["U_Email"];

            return true;
        }
    }
}
