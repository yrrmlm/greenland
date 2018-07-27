using com.greenland.adminservice.User;
using com.greenland.enums.Common;
using com.greenland.model.AdminModel;
using com.greenland.model.AdminModel.Request.User;
using com.greenland.model.AdminModel.Response.User;
using com.greenland.tool.Extension;
using Newtonsoft.Json;
using System.Linq;
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


        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage Add(UserAddReq req)
        {
            var result = userService.AddUser(req);
            var vRes = new VResponse
            {
                body = result
            };

            return WriteResponse(vRes);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("edit")]
        public HttpResponseMessage Edit(UserEditReq req)
        {
            var result = userService.EditUser(req);
            var vRes = new VResponse
            {
                body = result
            };

            return WriteResponse(vRes);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("remove")]
        public HttpResponseMessage Remove(UserRemoveReq req)
        {
            var result = userService.RemoveUser(req.userId);
            var vRes = new VResponse
            {
                body = result
            };

            return WriteResponse(vRes);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("list")]
        public HttpResponseMessage List(UserListReq req)
        {
            var totalCount = 0;
            var users = userService.GetUsers(req,out totalCount);
            var vRes = new VResponse
            {
                header = new VHeader
                {
                    rspCode = (int)RspCodeEnum.RspCode_0000,
                    rspDesc = RspCodeEnum.RspCode_0000.GetEnumDesc()
                },
                body = new VUserListRep
                {
                    userList = users,
                    curPage = req.pageIndex,
                    totalPage = totalCount
                }
            };
            return WriteResponse(vRes);
        }
    }
}
