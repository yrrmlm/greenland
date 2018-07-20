/**
* 命名空间: com.greenland.model.AdminModel.Request
*
* 功 能： N/A
* 类 名： LoginReq
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/19 10:21:18 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.model.AdminModel.Request
{
    public class LoginReq
    {
        public string loginName { get; set; }

        public string password { get; set; }
    }
}
