using com.greenland.adminservice.User;
using com.greenland.enums.Common;
using com.greenland.model.AdminModel;
using com.greenland.model.AdminModel.Request;
using com.greenland.model.AdminModel.Response;
using com.greenland.tool.Encryption.AES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace com.greenland.admingate.Controllers
{
    public class AuthController : BaseController
    {
        private LoginService _loginService = new LoginService();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage Login(LoginReq req)
        {
            var vRes = new VResponse();
            var vUser = _loginService.Login(req);
            if(vUser != null)
            {
                vRes = new VResponse
                {
                    body = new LoginRep { sessionCode = AESHelper.AesEncrypt(vUser.loginName + vUser.loginPwd) }
                };
            }
            else
            {
                vRes = new VResponse
                {
                    header = new VHeader { rspCode = (int)RspCodeEnum.RspCode_1000 }
                };
            }
            return WriteResponse(vRes);
        }
    }
}
