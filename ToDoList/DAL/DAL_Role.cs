using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DAL_Role
    {
        public string getRoleNameByID(int idRole)
        {
            string role = "";
            string query = "Select R_Name from [Role] where R_ID='" + idRole + "'";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                role = reader.GetString(0);
            conn.Close();
            return role;
        }
    }
}
