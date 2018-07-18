using com.greenland.adminservice.User;
using com.greenland.model.AdminModel;
using com.greenland.model.AdminModel.Request;
using com.greenland.model.AdminModel.Response;
using com.greenland.tool.DB;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace com.greenland.admingate.Controllers
{
    public class AccountController : BaseController
    {
        public UserService userService;

        public AccountController()
        {
            userService = new UserService();
        }

        [HttpGet]
        [HttpPost]
        [HttpOptions]
        public HttpResponseMessage Users(UserListReq req)
        {         
            try
            {
                var users = userService.GetUsers();
                var vRes = new VResponse<List<VUser>> { data = users.Skip(req.pageSize * (req.pageIndex-1)).Take(req.pageSize).ToList(), pager = new VPage { curPage = req.pageIndex, totalPage = users.Count() } };
                return WriteResponse(JsonConvert.SerializeObject(vRes));
            }
            catch(Exception ex)
            {
                return WriteResponse(ex.Message);
            }
        }
    }
}
