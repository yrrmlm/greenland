

using com.greenland.dataaccess.Admin;
using com.greenland.model.AdminModel.Request;
using com.greenland.model.AdminModel.Response.User;
/**
* 命名空间: com.greenland.adminservice.User
*
* 功 能： N/A
* 类 名： LoginService
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/27 15:45:12 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.adminservice.User
{
    public class LoginService
    {
        private static UserAccess _userAccess = new UserAccess();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public VUserRep Login(LoginReq req)
        {
            VUserRep vUser = null;
            try
            {
                var user = _userAccess.GetLoginUser(req.loginName, req.password);
                if(user != null)
                {
                    vUser = new VUserRep
                    {
                        loginName = user.Loginname,
                        loginPwd = user.Loginpwd
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vUser;
        }
    }
}
