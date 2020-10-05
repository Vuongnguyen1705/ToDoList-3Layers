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

        public DTO_Comment(int commentID, int commentUserID, int commentWorkID, int commentContent)
        {
            CommentID = commentID;
            CommentUserID = commentUserID;
            CommentWorkID = commentWorkID;
            CommentContent = commentContent;
        }

        public int CommentID { get; set; }
        public int CommentUserID { get; set; }
        public int CommentWorkID { get; set; }
        public int CommentContent { get; set; }
    }
}
