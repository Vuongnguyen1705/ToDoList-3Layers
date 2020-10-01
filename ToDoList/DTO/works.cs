using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class works
    {
        private string workID;
        private string workTitle;
        private DateTime workStartDate;
        private DateTime workEndDate;
        private string workState;
        private string workRange;
        private string workCoWorker;
        private string workAttachment;
        private string workUserID;

        public string WorkID { get => workID; set => workID = value; }
        public string WorkTitle { get => workTitle; set => workTitle = value; }
        public DateTime WorkStartDate { get => workStartDate; set => workStartDate = value; }
        public DateTime WorkEndDate { get => workEndDate; set => workEndDate = value; }
        public string WorkState { get => workState; set => workState = value; }
        public string WorkRange { get => workRange; set => workRange = value; }
        public string WorkCoWorker { get => workCoWorker; set => workCoWorker = value; }
        public string WorkAttachment { get => workAttachment; set => workAttachment = value; }
        public string WorkUserID { get => workUserID; set => workUserID = value; }

        public works(string workID, string workTitle, DateTime workStartDate, DateTime workEndDate, string workState, string workRange, string workCoWorker, string workAttachment, string workUserID)
        {
            this.WorkID = workID;
            this.WorkTitle = workTitle;
            this.WorkStartDate = workStartDate;
            this.WorkEndDate = workEndDate;
            this.WorkState = workState;
            this.WorkRange = workRange;
            this.WorkCoWorker = workCoWorker;
            this.WorkAttachment = workAttachment;
            this.WorkUserID = workUserID;
        }

        public works()
        {
        }
    }
}
