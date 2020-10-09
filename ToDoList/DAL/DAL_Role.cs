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

        public int getIDByRoleName(string RoleName)
        {
            int id = 0;
            string query = "Select R_ID from [Role] where R_Name='" + RoleName + "'";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                id = reader.GetInt32(0);
            conn.Close();
            return id;
        }
    }
}
