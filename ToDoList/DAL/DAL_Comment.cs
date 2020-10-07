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
    }
}
