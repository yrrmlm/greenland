
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.greenland.dataaccess.Admin;
using com.greenland.model.AdminModel;
using com.greenland.model.AdminModel.Response;
using com.greenland.model.AdminModel.Response.User;
using com.greenland.tool.Settings;
using com.greenland.model.AdminModel.Request.User;
/**
* 命名空间: com.greenland.adminservice.User
*
* 功 能： N/A
* 类 名： UserService
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 13:17:20 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

namespace com.greenland.adminservice.User
{
    public class UserService
    {
        private static UserAccess _userAccess = new UserAccess();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<VUserRep> GetUsers(UserListReq req,out int totalCount)
        {
            totalCount = 0;
            var vUsers = new List<VUserRep>();
            try
            {
                var users = _userAccess.AllUsers(req, out totalCount);
                if (users != null)
                {
                    users.ForEach(p => vUsers.Add(new VUserRep
                    {
                        id = p.Id,
                        loginName = p.Loginname,
                        loginPwd = "*********",
                        isActive = p.Isactive,
                        createBy = p.Createby,
                        createTime = p.Createtime.ToString(StringDateFormat.DateFormatDayMinitues),
                        updateBy = p.Updateby,
                        updateTime = p.Updatetime.ToString(StringDateFormat.DateFormatDayMinitues)
                    }));
                }
            }
            catch(Exception ex)
            {

            }
            return vUsers;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool RemoveUser(int userId)
        {
            var res = true;
            try
            {
                if (userId > 0)
                {
                    res = _userAccess.RemoveUser(userId);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool EditUser(UserEditReq req)
        {
            var res = true;
            try
            {
                if (req != null && req.userId > 0)
                {
                    res = _userAccess.UpdateUser(new entity.User.UserEntity
                    {
                        Id = req.userId,
                        Loginname = req.loginName,
                        Loginpwd = req.loginPwd
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool AddUser(UserAddReq req)
        {
            var res = true;
            try
            {
                if (req != null)
                {
                    res = _userAccess.AddUser(new entity.User.UserEntity
                    {
                        Loginname = req.loginName,
                        Loginpwd = req.loginPwd
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}
