using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobPortal.Models;
using JobPortal.BusinessModel;


namespace JobPortal.Controllers
{
    public class RoleMenuController : ApiController
    {
        [HttpGet]
        public ApiResult GetMenu()
        {
            Menu objmenu = new Menu();
            return new ApiResult()
            {
                ObjData = objmenu.GetMenu().OrderBy(x=>x.MenuId),
                Token = "meesam",
                Status = ResultModel.SUCCESS,
                Count = 1
            };
        }

        [HttpGet]
        public ApiResult GetUserRole(int userId)
        {
            UserRole objUserRole = new UserRole();
            var data = objUserRole.GetUserRole().Where(x => x.UserId == userId);
            return new ApiResult()
            {
                ObjData = data,
                Token = "meesam",
                Status = ResultModel.SUCCESS,
                Count = 1
            };
        }

        [HttpGet]
        [ActionName("GetSubMenu")]
        public ApiResult GetSubMenu(int menuId)
        {
            SubMenu objmenu = new SubMenu();
            var data = objmenu.GetSubMenu().Where(x => x.MenuId == menuId);
            return new ApiResult()
            {
                ObjData = data,
                Token = "meesam",
                Status = ResultModel.SUCCESS,
                Count = data.Count()
            };
        }
    }
}
