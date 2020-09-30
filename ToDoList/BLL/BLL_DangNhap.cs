using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BLL_DangNhap
    {
        DAL_DangNhap dangNhap = new DAL_DangNhap();
        public bool TryLogin(string email, string password)
        {
            return dangNhap.TryLogin(email, password);
        }
    }
}
