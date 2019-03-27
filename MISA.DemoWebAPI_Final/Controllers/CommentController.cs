using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.DemoWebAPI_Final.Controllers
{
    public class CommentController : ApiController
    {
        CommentBLL _commentBll = new CommentBLL();
       public List<Comment> GetListComment()
        {
            return _commentBll.GetListComment();
        } 
    }
}
