/**
* 命名空间: com.greenland.model.AdminModel.Request.User
*
* 功 能： N/A
* 类 名： UserAddReq
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/27 11:13:40 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.model.AdminModel.Request.User
{
    public class UserAddReq: BaseReq
    {
        public string loginName { get; set; }

        public string loginPwd { get; set; }
    }
}
