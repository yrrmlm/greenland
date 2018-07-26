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

        [HttpPost]
        [ActionName("users")]
        public HttpResponseMessage Users(UserListReq req)
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
                    userList = users.Skip(req.pageSize * (req.pageIndex - 1)).Take(req.pageSize).ToList(),
                    curPage = req.pageIndex,
                    totalPage = totalCount/req.pageSize == 0 ? 1: totalCount / req.pageSize
                }
            };
            return WriteResponse(vRes);
        }
    }
}
