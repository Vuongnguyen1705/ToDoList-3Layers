using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Text;

namespace DTO
{
    public class DTO_Comment
    {
        public DTO_Comment()
        {
        }

        public DTO_Comment(int commentID, string commentUserID, int commentWorkID, string commentContent)
        {
            CommentID = commentID;
            CommentUserID = commentUserID;
            CommentWorkID = commentWorkID;
            CommentContent = commentContent;
        }

        public int CommentID { get; set; }
        public string CommentUserID { get; set; }
        public int CommentWorkID { get; set; }
        public string CommentContent { get; set; }
    }
}
