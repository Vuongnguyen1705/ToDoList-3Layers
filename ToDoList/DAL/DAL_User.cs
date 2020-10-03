using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DAL_User
    {
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

        public void InsertUpdateDeleteSQLString(string query)
        {
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddUser(DTO_User u)
        {
            DataSet ds = new DataSet();
            string query = "INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender,U_IsEnable, U_Role_ID) VALUES ('" + u.UserAvatar + "',N'" + u.UserFullName + "','" + u.UserPhoneNumber + "',N'" + u.UserEmail + "','" + u.UserPassword + "','" + u.UserAddress + "','" + u.UserBirthday + "','" + u.UserGender + "','" + u.UserIsEnable + "','" + u.UserRoleID + "')";
            InsertUpdateDeleteSQLString(query);
        }

        public void UpdateUser(DTO_User u)
        {
            DataSet ds = new DataSet();           
            string query = "UPDATE dbo.Users SET U_Avatar ='" + u.UserAvatar + "', U_FullName = N'" + u.UserFullName + "', U_Phone = '" + u.UserPhoneNumber + "', U_Email = N'" + u.UserEmail + "', U_Password = '" + u.UserPassword + "', U_Address = N'" + u.UserAddress + "', U_Birthday = '" + u.UserBirthday + "', U_Gender = '" + u.UserGender + "', U_IsEnable = '" + u.UserIsEnable + "', U_Role_ID = " + u.UserRoleID + " WHERE U_ID = " + u.UserID;
            InsertUpdateDeleteSQLString(query);
        }

        public void DeleteUser(int UserID)
        {
            DataSet ds = new DataSet();
            string query = "DELETE FROM dbo.Users WHERE U_ID = '" + UserID + "' ";
            InsertUpdateDeleteSQLString(query);
        }
    }
}
