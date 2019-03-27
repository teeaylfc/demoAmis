using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Entity;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace MISA.DemoWebAPI_Final.Controllers
{
    public class UserController : ApiController
    {
        UserBLL _userBLL;
     

        [HttpGet]
        public bool CheckInfoLogin(string userName, string password)
        {
            _userBLL = new UserBLL();
            return _userBLL.CheckUserLogin(userName,password);
        }
        public void PostRegisterAccount([FromBody] User user) {   //Đăng kí tài khoản
            _userBLL.RegisterAcount(user);

        }

    }
}
