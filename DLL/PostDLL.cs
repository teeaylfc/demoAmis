using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class PostDLL
    {
        DataAccess _dataAccess;
        public PostDLL()
        {
            _dataAccess = new DataAccess();
        }

        public List<Post> GetListPost()
        {
            return _dataAccess.GetListPost();
        }
    }
}
