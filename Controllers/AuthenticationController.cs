﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobPortal.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using JobPortal.BusinessModel;

namespace JobPortal.Controllers
{
    public class AuthenticationController : ApiController
    {
        UserLoginBL _objUserBL = new UserLoginBL();
        [HttpPost]
        public ApiResult doLogin([FromBody]UserLogin userInfo)
        {
            var data= _objUserBL.doLogin(userInfo.UserName, userInfo.Password);
            var formatter = new BinaryFormatter();
            if (data != null)
            {
                return new ApiResult()
                {
                    ObjData = data,
                    Token = data.ToString(),
                    Status = ResultModel.SUCCESS,
                    Count=1
                };
            }
            else
            {
                return new ApiResult()
                {
                    Status = ResultModel.SUCCESS,
                    Count=0
                };
            }
        }
    }
}