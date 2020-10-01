using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class DTO_Work
    {   
        public DTO_Work(string workID, string workTitle, long workStartDate, long workEndDate, string workState, string workRange, string workCoWorker, string workAttachment, string workUserID)
        {
            WorkID = workID;
            WorkTitle = workTitle;
            WorkStartDate = workStartDate;
            WorkEndDate = workEndDate;
            WorkState = workState;
            WorkRange = workRange;
            WorkCoWorker = workCoWorker;
            WorkAttachment = workAttachment;
            WorkUserID = workUserID;
        }

        public DTO_Work()
        {
        }

        public string WorkID { get; set; }
        public string WorkTitle { get; set; }
        public long WorkStartDate { get; set; }
        public long WorkEndDate { get; set; }
        public string WorkState { get; set; }
        public string WorkRange { get; set; }
        public string WorkCoWorker { get; set; }
        public string WorkAttachment { get; set; }
        public string WorkUserID { get; set; }
    }
}
