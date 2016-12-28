using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobPortal.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace JobPortal.Controllers
{
    public class AuthenticationController : ApiController
    {
        UserLoginBL _objUserBL = new UserLoginBL();
        [HttpPost]
        public ApiResult doLogin([FromBody]object value)
        {
            var data= _objUserBL.doLogin("meesam","meesam");
            var formatter = new BinaryFormatter();
            return new ApiResult()
            {
                 ObjData= data,
                 Token= data.ToString(),
                 Status =ResultModel.SUCCESS
            };
        }
    }
}
