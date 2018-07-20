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
    public class UserController : BaseController
    {
        public UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Users(UserListReq req)
        {
            var users = userService.GetUsers();
            var vRes = new VResponse<List<VUser>>
            {
                data = users.Skip(req.pageSize * (req.pageIndex - 1)).Take(req.pageSize).ToList(),
                pager = new VPage { curPage = req.pageIndex, totalPage = users.Count() }
            };
            return WriteResponse(JsonConvert.SerializeObject(vRes));
        }

        [HttpPost]
        public HttpResponseMessage Delete()
        {
            return WriteResponse("No implement...");
        }
    }
}
