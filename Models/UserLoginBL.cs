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
            var userDate = (from d in GetAll() where d.UserName==username && d.Password==password
                           select d)
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

    public class UserRole
    {
        public string[] Roles { get; set; }
        public int UserId { get; set; }

        public List<UserRole> GetUserRole()
        {
            return new List<UserRole>() {
                 new UserRole() {
                      UserId=1,
                      Roles=new string[] { "Admin","Consultant" }
                 },
                 new UserRole() {
                     UserId=2,
                      Roles=new string[] { "Consultant" }
                 },
                 new UserRole() {
                     UserId=4,
                      Roles=new string[] { "Admin" }
                 }
            };
        }
        
    }

    public class Menu
    {
        public int MenuId{ get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
    }


}