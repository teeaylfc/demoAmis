using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DLL
{
    public class CommentDLL
    {
        DataAccess _dataAccess;
        public CommentDLL()
        {
            _dataAccess = new DataAccess();

        }
            public List<Comment> GetListComment()
            {
            return _dataAccess.GetListComment();
            }
        }

    }
