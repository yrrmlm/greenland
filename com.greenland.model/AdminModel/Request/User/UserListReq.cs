﻿/**
* 命名空间: com.greenland.model.AdminModel.Request
*
* 功 能： N/A
* 类 名： userReq
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/18 18:28:24 liumin 初版
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
    public class UserListReq : PageReq
    {
        public string searchWord { get; set; }
    }
}
