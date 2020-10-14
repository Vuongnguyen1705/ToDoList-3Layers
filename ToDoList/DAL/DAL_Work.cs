using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;
using System.Linq;
namespace DAL
{
    public class DAL_Work
    {
        public ObservableCollection<DTO_Work> getAll()
        {
            General general = new General();
            ObservableCollection<DTO_Work> works = new ObservableCollection<DTO_Work>();
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
                    string coWorkerID = reader.GetString(6);
                        works.Add(new DTO_Work(reader.GetInt32(0), reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetDateTime(3),
                            reader.GetString(4), reader.GetString(5), coWorkerID.ToString(),
                            reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public ObservableCollection<DTO_Work> getById(int id)
        {
            General general = new General();
            ObservableCollection<DTO_Work> works = new ObservableCollection<DTO_Work>();
            DAL_User dAL_User = new DAL_User();
            string query = "Select * from [Works] where W_ID=" + id;
            var conn = Connection.Instance;
            conn.Open();
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }

        public List<DTO_Work> getWorkById(int id)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query = "Select * from [Works] where W_User_ID=" + id + "OR W_CoWorker ="+id;
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> getPartnerWorkPublic(int id)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query = "Select * from [Works] where W_User_ID!=" + id + "AND W_Range ='Public'";
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> FillterRange(string range)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query;
            if (range.Equals("Tất cả"))
            {
                query = "Select * from [Works]";
            }
            else {
                query = "Select * from [Works] where W_Range='" + range + "'"; 
            }
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> FillterStatus(string status)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query;
            if (status.Equals("Tất cả"))
            {
                query = "Select * from [Works]";
            }
            else
            {
                query = "Select * from [Works] where W_State=N'" + status + "'";
            }
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> FillterDateStart(DateTime datetime)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query;
            query = "Select * from [Works] where W_StartDate >'" + datetime + "'";
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> FillterDateEnd(DateTime datetime)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query;
            query = "Select * from [Works] where W_EndDate <'" + datetime + "'";
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
                }
                reader.NextResult();
            }
            conn.Close();
            return works;
        }
        public List<DTO_Work> FillterAll(string range, string state, DateTime dateStart, DateTime dateEnd)
        {
            List<DTO_Work> works = new List<DTO_Work>();
            var conn = Connection.Instance;
            conn.Open();
            string query;
            string startDate = "", endDate = "";
            /*if (range!="")
            {
                if (state != "")
                {
                    if (dateStart.ToString() != "")
                    {
                        if (dateEnd.ToString() != "")
                        {
                            query = "Select * from [Works] where W_StartDate >='" + dateStart + "' and W_EndDate <='" + dateEnd + "' and W_State=N'" + state + "' and W_Range='" + range+"'";
                        }
                        else
                        {
                            query = "Select * from [Works] where  W_Range= " + range + "and W_State=N'" + state + "'";
                        }
                    }
                    else if (dateEnd.ToString() != "")
                    {
                        query = "Select * from [Works] where W_EndDate <='" + dateEnd + "' and W_State=N'" + state + "' and W_Range='" + range + "'";
                    }
                    else
                    {
                        query = "Select * from [Works] where  W_Range= " + range + "and W_State=N'" + state + "' and W_StartDate <='" + dateStart + "'";
                    }
                }
                else if (dateStart.ToString() != "")
                {
                    if (dateEnd.ToString() != "")
                    {
                        query = "Select * from [Works] where W_StartDate >='" + dateStart + "' and W_EndDate <='" + dateEnd + "' and W_Range='" + range + "'";
                    }
                    else
                    {
                        query = "Select * from [Works] where W_StartDate >='" + dateStart + "' and W_Range='" + range + "'";
                    }
                }
                else if (dateEnd.ToString() != "")
                {

                }
                else
                {
                    query = "Select * from [Works] where  W_Range= '" + range+"'";
                }
            }*/
            query = "Select * from [Works] where 1=1";
            if (range != ""&&!range.Equals("Tất cả"))
            {
                range = " and W_Range=N'" + range+"'";
                query += range;
            }
            if (state != "" && !state.Equals("Tất cả"))
            {
                state = " and W_State=N'" + state + "'";
                query += state;
            }
            if (dateStart.ToString() != "")
            {
                startDate = " and W_StartDate >='" + dateStart + "'";
                query += startDate;
            }
            if (dateEnd.ToString() != "")
            {
                endDate = " and W_EndDate <='" + dateEnd + "'";
                query += endDate;
            }
            //query = "Select * from [Works] where W_StartDate >='" + dateStart + "' and W_EndDate <='"+dateEnd+"' and W_State=N'"+state+"' and W_Range="+range;
            //query = "Select * from [Works] where 1=1 " + range + " " + state + " " + startDate + " " + endDate + " ";
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
                        reader.GetString(7), reader.GetInt32(8).ToString()));
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
            rangeList.Add("Public");
            rangeList.Add("Private");
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

        public void AddWork(DTO_Work w)
        {
            string query = "INSERT INTO dbo.Works(W_Title, W_StartDate, W_EndDate, W_State, W_Range, W_CoWorker, W_Attachments, W_User_ID) VALUES (N'" + w.WorkTitle + "','" + w.WorkStartDate + "','" + w.WorkEndDate + "',N'" + w.WorkStatus + "',N'" + w.WorkRange + "','" + w.WorkCoWorker + "','" + w.WorkAttachment + "','" + w.WorkUserID + "')";
            InsertUpdateDeleteSQLString(query);
        }

        public void UpdateWork(DTO_Work w)
        {
            string query = "UPDATE dbo.Works SET W_Title = N'" + w.WorkTitle + "', W_StartDate = '" + w.WorkStartDate + "', W_EndDate = '" + w.WorkEndDate + "', W_State = N'" + w.WorkStatus + "', W_Range = N'" + w.WorkRange + "', W_CoWorker = '" + w.WorkCoWorker + "', W_Attachments = '" + w.WorkAttachment + "', W_User_ID = '" + w.WorkUserID + "' WHERE W_ID = " + w.WorkID;
            InsertUpdateDeleteSQLString(query);
        }

        public void DeleteWork(int WorkID)
        {
            string query = "DELETE FROM dbo.Works WHERE W_ID = '" + WorkID + "' ";
            InsertUpdateDeleteSQLString(query);
        }
    }

}
