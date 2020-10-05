using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DAL_User
    {
        public List<DTO_User> getAll()
        {
            General general = new General();
            List<DTO_User> user = new List<DTO_User>();
            
            string query = "Select * from [Users]";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.Add(new DTO_User(reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6),
                        reader.GetDateTime(7), reader.GetString(8),reader.GetBoolean(9),reader.GetInt32(10)));

                }
                reader.NextResult();
            }
            conn.Close();
            return user;
        }

        public DTO_User getUserByID(int id)
        {
            General general = new General();
            DTO_User user=new DTO_User();
            string query = "Select * from [Users] where U_ID=@userID";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userID", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.UserID = Int32.Parse(reader["U_ID"].ToString());
                user.UserAvatar = reader["U_Avatar"].ToString();
                user.UserFullName = reader["U_FullName"].ToString();
                user.UserPhoneNumber = reader["U_Phone"].ToString();
                user.UserPassword = reader["U_Password"].ToString();
                user.UserAddress = reader["U_Address"].ToString();
                user.UserBirthday = (DateTime)reader["U_Birthday"];
                user.UserGender = reader["U_Gender"].ToString();
                user.UserIsEnable = (bool)reader["U_IsEnable"];
                user.UserRoleID =Int32.Parse(reader["U_Role_ID"].ToString());   
            }
            conn.Close();
            return user;
        }

        public DTO_User getUserByEmail(string email)
        {
            General general = new General();
            DTO_User user = new DTO_User();
            string query = "Select * from [Users] where U_Email=@userEmail";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userEmail", email);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.UserID = Int32.Parse(reader["U_ID"].ToString());
                user.UserAvatar = reader["U_Avatar"].ToString();
                user.UserFullName = reader["U_FullName"].ToString();
                user.UserEmail = reader["U_Email"].ToString();
                user.UserPhoneNumber = reader["U_Phone"].ToString();
                user.UserPassword = reader["U_Password"].ToString();
                user.UserAddress = reader["U_Address"].ToString();
                user.UserBirthday = (DateTime)reader["U_Birthday"];
                user.UserGender = reader["U_Gender"].ToString();
                user.UserIsEnable = (bool)reader["U_IsEnable"];
                user.UserRoleID = Int32.Parse(reader["U_Role_ID"].ToString());
            }
            conn.Close();
            return user;
        }

        public int getRoleIDByEmail(string email)
        {
            int roleID=0;
            string query = "Select U_Role_ID from [Users] where U_Email='"+email+"'";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
               roleID = reader.GetInt32(0);           
            conn.Close();
            return roleID;
        }

        public string getFullNameByID(int idUser)
        {
            string fullName = "";
            string query = "Select U_FullName from [Users] where U_ID='" + idUser + "'";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                fullName = reader.GetString(0);
            conn.Close();
            return fullName;
        }
    }
}
