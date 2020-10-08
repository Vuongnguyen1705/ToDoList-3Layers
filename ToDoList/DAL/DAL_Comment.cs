using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DAL_Comment
    {
        public ObservableCollection<DTO_Comment> getAll()
        {
            General general = new General();
            ObservableCollection<DTO_Comment> comment = new ObservableCollection<DTO_Comment>();

            string query = "Select * from [Comments]";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    comment.Add(new DTO_Comment(reader.GetInt32(0), reader.GetInt32(1).ToString(), reader.GetInt32(2), reader.GetString(3)));
                }
                reader.NextResult();
            }
            conn.Close();
            return comment;
        }

        public ObservableCollection<DTO_Comment> getCommentByIDWork(int idWork)
        {
            General general = new General();
            ObservableCollection<DTO_Comment> comment = new ObservableCollection<DTO_Comment>();

            string query = "Select * from [Comments] where CMT_Work_ID= "+idWork;
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    comment.Add(new DTO_Comment(reader.GetInt32(0), reader.GetInt32(1).ToString(), reader.GetInt32(2), reader.GetString(3)));
                }
                reader.NextResult();
            }
            conn.Close();
            return comment;
        }

        public void insertComment(DTO_Comment comment)
        {
            var conn = Connection.Instance;
            conn.Open();
            string query = "insert into [Comments] values(@userID, @workID, @comment)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userID", comment.CommentUserID);
            command.Parameters.AddWithValue("@workID", comment.CommentWorkID);
            command.Parameters.AddWithValue("@comment", comment.CommentContent);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
