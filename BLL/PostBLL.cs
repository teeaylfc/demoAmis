using DLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PostBLL
    {
        // Khởi tạo DLL:
        PostDLL _postDLL;
        public PostBLL()
        {
            _postDLL = new PostDLL();
        }

        public List<Post> GetListPost()
        {
            return _postDLL.GetListPost();
        }
    }
}
