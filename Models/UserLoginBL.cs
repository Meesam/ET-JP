using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.BusinessModel;

namespace JobPortal.Models
{
    public class UserLoginBL:CoreModel<JobPortalContext,UserLogin>
    {
        public object doLogin(string username,string password)
        {
            var userDate = FindBy(x => x.UserName == username && x.Password == password)
                .Select(y=>new {
                    Name = y.Name,
                    CreateDate = y.CreateDate,
                    LoginDate = y.LoginDate,
                    UserName = y.UserName,
                    UserId = y.UserId
                }).FirstOrDefault();
            return userDate;
        }
    }
}