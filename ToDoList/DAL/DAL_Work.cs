using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;
using System.Linq;
namespace DAL
{
    public class DAL_Work
    {
        public List<DTO_Work> getAll()
        {
            General general = new General();
            List<DTO_Work> works = new List<DTO_Work>();
            DAL_User dAL_User = new DAL_User();
            string query= "Select * from [Works]";
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand command = new SqlCommand(query,conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    string coWorkerID =reader.GetString(6);
                    
           
                        works.Add(new DTO_Work(reader.GetInt32(0), reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetDateTime(3),
                            reader.GetString(4), reader.GetString(5), coWorkerID.ToString(),
                            reader.GetString(7), reader.GetInt32(8)));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> getById(int id)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query = "Select * from [Works] where WorkID="+id;
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    string coWorkerID = reader.GetString(6);
                    works.Add(new DTO_Work(reader.GetInt32(0), reader.GetString(1),
                        reader.GetDateTime(2),
                        reader.GetDateTime(3),
                        reader.GetString(4), reader.GetString(5), coWorkerID.ToString(),
                        reader.GetString(7), reader.GetInt32(8)));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<string> getStatus()
        {
            var statusList = new List<string>();
            statusList.Add("Tất cả");
            statusList.Add("Đang làm");
            statusList.Add("Đã xong");
            statusList.Add("Trễ hạn");
            return statusList;
        }

        public List<string> getRange()
        {
            var rangeList = new List<string>();
            rangeList.Add("Tất cả");
            rangeList.Add("Công khai");
            rangeList.Add("Riêng tư");
            return rangeList;
        }

        public void InsertUpdateDeleteSQLString(string query)
        {
            var conn = Connection.Instance;
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddWork(string title, DateTime startDate, DateTime endDate, string state, string range, string coWorker,string attachment, int userid)
        {
            DataSet ds = new DataSet();
            string query = "INSERT INTO dbo.Works(W_Title, W_StartDate, W_EndDate, W_State, W_Range, W_CoWorker, W_Attachments, W_User_ID) VALUES (N'" + title + "','" + startDate + "','" + endDate + "',N'" + state + "',N'" + range + "','" + coWorker + "','" + attachment + "','" + userid + "')";
            InsertUpdateDeleteSQLString(query);
        }

        public void UpdateWork(DTO_Work w)
        {
            DataSet ds = new DataSet();
            string query = "UPDATE dbo.Works SET W_Title = N'" + w.WorkTitle + "', W_StartDate = '" + w.WorkStartDate + "', W_EndDate = '" + w.WorkEndDate + "', W_State = N'" + w.WorkStatus + "', W_Range = N'" + w.WorkRange + "', W_CoWorker = '" + w.WorkCoWorker + "', W_Attachments = '" + w.WorkAttachment + "', W_User_ID = '" + w.WorkUserID + "' WHERE W_ID = " + w.WorkID;
            InsertUpdateDeleteSQLString(query);
        }

        public void DeleteWork(int WorkID)
        {
            DataSet ds = new DataSet();
            string query = "DELETE FROM dbo.Works WHERE W_ID = '" + WorkID + "' ";
            InsertUpdateDeleteSQLString(query);
        }
    }

}
