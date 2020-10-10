using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Connection
    {
        private static SqlConnection connection;
        private static string connectionString = @"Data Source=LAPTOP-E6M8GE8F\SQLEXPRESS; Initial Catalog=ToDoList; Integrated Security=True;";

        public static SqlConnection Instance
        {
            get
            {
                if(connection == null)
                {
                    connection = new SqlConnection(connectionString);   
                }
                return connection;
            }
        }
        
        public static DataTable DoQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, Instance);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Instance.Close();
            return dataTable;
        }

        public SqlCommand GetValue(string query)
        {
            Instance.Open();
            SqlCommand cmd = new SqlCommand(query, Instance);
            return cmd;
        }

        public int Change(string query)
        {
            Instance.Open();
            SqlCommand cmd = new SqlCommand(query, Instance);
            int isChange = cmd.ExecuteNonQuery();
            Instance.Close();
            return isChange;
        }
        public void Close()
        {
            Instance.Close();
        }

    }
}
