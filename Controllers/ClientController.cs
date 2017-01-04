using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobPortal.Models;


namespace JobPortal.Controllers
{
    public class ClientController : ApiController
    {
        ClientBL objClientBL = new ClientBL();
        [HttpPost]
        public ApiResult getClient([FromBody]object userInfo)
        {
            var data = objClientBL.GetCleint();
            return new ApiResult()
            {
                ObjData = data,
                Token = "meesam",
                Status = ResultModel.SUCCESS,
                Count = data.Count
            };
        }
    }
}
