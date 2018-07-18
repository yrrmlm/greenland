

using com.greenland.dataaccess.Admin;
using com.greenland.model.AdminModel;
using com.greenland.model.AdminModel.Response;
using com.greenland.tool.Settings;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.adminservice.User
{
    public class UserService
    {
        private static UserAccess _userAccess = new UserAccess();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<VUser> GetUsers()
        {
            var vUsers = new List<VUser>();
            try
            {
                var users = _userAccess.AllUsers();
                if (users != null)
                {
                    users.ForEach(p => vUsers.Add(new VUser
                    {
                        id = p.Id,
                        loginName = p.Loginname,
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
    }
}
