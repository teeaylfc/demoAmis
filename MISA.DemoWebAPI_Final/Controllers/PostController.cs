using BLL;
using DLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.DemoWebAPI_Final.Controllers
{
    public class PostController : ApiController
    {
        PostBLL _postBLL;
         DataAccess dataAccess;
        public PostController()
        {
            dataAccess = new DataAccess();
            _postBLL = new PostBLL();
        }
        public List<Entity.Post> GetListPost()
        {
            List<Entity.Post> posts = _postBLL.GetListPost();

            return posts;
        }


        [HttpPost]
        public bool UpPost([FromBody] Post post)
        {
            return dataAccess.UpPost(post);
        }

    }
   
}
