using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Work
    {
        public DTO_Work()
        {
        }

        public DTO_Work(int workID, string workTitle, DateTime workStartDate, DateTime workEndDate, string workStatus, string workRange, string workCoWorker, string workAttachment, string workUserID)
        {
            WorkID = workID;
            WorkTitle = workTitle;
            WorkStartDate = workStartDate;
            WorkEndDate = workEndDate;
            WorkStatus = workStatus;
            WorkRange = workRange;
            WorkCoWorker = workCoWorker;
            WorkAttachment = workAttachment;
            WorkUserID = workUserID;
        }
        
        public int WorkID { get; set; }
        public string WorkTitle { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkEndDate { get; set; }
        public string WorkStatus { get; set; }
        public string WorkRange { get; set; }
        public string WorkCoWorker { get; set; }
        public string WorkAttachment { get; set; }
        public string WorkUserID { get; set; }
    }
}
