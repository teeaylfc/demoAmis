using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Post
    {
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public Guid CommentID { get; set; }
        public string PostContent { get; set; }
        public string Avatar { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
