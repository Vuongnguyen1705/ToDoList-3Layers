using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Text;

namespace DTO
{
    class DTO_Comment
    {
        private int commentID;
        private int commentUserID;
        private int commentWorkID;
        private int commentContent;

        public DTO_Comment()
        {

        }
        public DTO_Comment(int commentID, int commentUserID, int commentWorkID, int commentContent)
        {
            this.CommentID = commentID;
            this.CommentUserID = commentUserID;
            this.CommentWorkID = commentWorkID;
            this.CommentContent = commentContent;
        }

        public int CommentID { get => commentID; set => commentID = value; }
        public int CommentUserID { get => commentUserID; set => commentUserID = value; }
        public int CommentWorkID { get => commentWorkID; set => commentWorkID = value; }
        public int CommentContent { get => commentContent; set => commentContent = value; }
    }
}
