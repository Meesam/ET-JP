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
            var userData = (from d in GetAll() where d.UserName==username && d.Password==password
                           select d)
                            .Select(y=>new {
                                Name = y.Name,
                                CreateDate = y.CreateDate,
                                LoginDate = y.LoginDate,
                                UserName = y.UserName,
                                UserId = y.UserId
                            }).FirstOrDefault();
            return userData;
        }

        public object getUserByToken(string username)
        {
            var userData = (from d in GetAll()
                            where d.UserName == username
                            select d)
                            .Select(y => new {
                                Name = y.Name,
                                CreateDate = y.CreateDate,
                                LoginDate = y.LoginDate,
                                UserName = y.UserName,
                                UserId = y.UserId
                            }).FirstOrDefault();
            return userData;
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
                     UserId=3,
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

        public List<Menu> GetMenu()
        {
            return new List<Menu>() {
                new Menu() {
                    MenuId=1,
                    MenuName="Consultant",
                    //Route="/consultant"
                },
                new Menu() {
                    MenuId=2,
                    MenuName="Candidates",
                    //Route="/candidate"
                },
                new Menu() {
                     MenuId=3,
                     MenuName="Clients",
                    // Route="/clients"
                },
                new Menu() {
                     MenuId=4,
                     MenuName="Mandates",
                     //Route="/mandates "
                }
                
            };
        }
    }

    public class SubMenu
    {
        public int MenuId { get; set; }
        public string SubMenuName { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }

        public List<SubMenu> GetSubMenu()
        {
            return new List<SubMenu>() {
                new SubMenu() {
                     MenuId=3,
                     SubMenuName="All Clients",
                     Icon="",
                     Route="/clients"
                },
                new SubMenu() {
                     MenuId=3,
                     SubMenuName="Add Client",
                     Icon="",
                     Route="/clients"
                },
                new SubMenu() {
                     MenuId=2,
                     SubMenuName="All Candidates",
                     Icon="",
                     Route="/candidate"
                },
                new SubMenu() {
                     MenuId=2,
                     SubMenuName="Add Candidate",
                     Icon="",
                     Route="/candidate"
                },
                new SubMenu() {
                     MenuId=2,
                     SubMenuName="Upload Candidates",
                     Icon="",
                     Route="/candidate"
                }
            };
        }
    }

}
