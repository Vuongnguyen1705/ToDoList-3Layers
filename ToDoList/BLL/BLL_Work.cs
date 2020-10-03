using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BLL_Work
    {
        DAL_Work dAL_Work = new DAL_Work();
        public List<DTO_Work> getAll()
        {
            return dAL_Work.getAll();
        }

        public List<string> getStatus()
        {
            return dAL_Work.getStatus();
        }

        public List<string> getRange()
        {
            return dAL_Work.getRange();
        }
    }
}
