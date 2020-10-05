using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
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
                    string coWorkerID = reader.GetString(6);
                    string[] arrIdUser= { };
                    if (!coWorkerID.Equals(""))
                        arrIdUser =coWorkerID.Split(",");
                    string coWorkerCount= arrIdUser.Length.ToString();

                    works.Add(new DTO_Work(reader.GetInt32(0), reader.GetString(1),
                        reader.GetDateTime(2),
                        reader.GetDateTime(3),
                        reader.GetString(4), reader.GetString(5), coWorkerCount, 
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
    }

}
