using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Threading.Tasks;
using DLL;

namespace BLL
{
    public class CommentBLL
    {
        // Khởi tạo DLL:
        CommentDLL _commentDLL;
        public CommentBLL()
        {
            _commentDLL = new CommentDLL();
        }

        public List<Comment> GetListComment()
        {
            return _commentDLL.GetListComment();
        }
    }
}
