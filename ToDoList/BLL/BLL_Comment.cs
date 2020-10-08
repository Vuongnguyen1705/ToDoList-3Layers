using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BLL
{
    public class BLL_Comment
    {
        DAL_Comment dAL_Comment = new DAL_Comment();
        public ObservableCollection<DTO_Comment> getAll()
        {
            return dAL_Comment.getAll();
        }

        public ObservableCollection<DTO_Comment> getCommentByIDWork(int idWork)
        {
            return dAL_Comment.getCommentByIDWork(idWork);
        }

        public void insertComment(DTO_Comment comment)
        {
            dAL_Comment.insertComment(comment);
        }
    }
}
