using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BLL
{
    public class BLL_Work
    {
        DAL_Work dAL_Work = new DAL_Work();
        public ObservableCollection<DTO_Work> getAll()
        {
            return dAL_Work.getAll();
        }
        public ObservableCollection<DTO_Work> getById(int id)
        {
            return dAL_Work.getById(id);
        }
        public List<DTO_Work> getWorkById(int id)
        {
            return dAL_Work.getWorkById(id);
        }
        public List<DTO_Work> getPartnerWorkPublic(int id)
        {
            return dAL_Work.getPartnerWorkPublic(id);
        }
        public List<DTO_Work> FillterRange(string range)
        {
            return dAL_Work.FillterRange(range);
        }
        public List<DTO_Work> FillterStatus(string status)
        {
            return dAL_Work.FillterStatus(status);
        }
        public List<DTO_Work> FillterDateStart(DateTime datetime)
        {
            return dAL_Work.FillterDateStart(datetime);
        }
        public List<DTO_Work> FillterDateEnd(DateTime datetime)
        {
            return dAL_Work.FillterDateEnd(datetime);
        }
        public List<DTO_Work> FillterAll(string range,string state,DateTime dateStart,DateTime dateEnd)
        {
            return dAL_Work.FillterAll(range, state, dateStart, dateEnd);
        }
        public List<string> getStatus()
        {
            return dAL_Work.getStatus();
        }

        public List<string> getRange()
        {
            return dAL_Work.getRange();
        }

        public void AddWork(string title, DateTime startDate, DateTime endDate, string state, string range, string coWorker, string attachment, int userid)
        {
            dAL_Work.AddWork(title, startDate,endDate, state,range,coWorker,attachment,userid);
        }

        public void UpdateWork(DTO_Work w)
        {
            dAL_Work.UpdateWork(w);
        }

        public void DeleteWork(int WorkID)
        {
            dAL_Work.DeleteWork(WorkID);
        }
    }
}
