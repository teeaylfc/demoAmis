using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Comment
    {
        public Guid CommentID  { get; set; }
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
        public String CommentContent { get; set; }
        public String CreatedDate { get; set; }
    }
}
