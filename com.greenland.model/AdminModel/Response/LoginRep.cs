/**
* 命名空间: com.greenland.model.AdminModel.Response
*
* 功 能： N/A
* 类 名： LoginRep
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/27 15:57:35 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.model.AdminModel.Response
{
    public class LoginRep
    {
        /// <summary>
        /// 身份验证凭证
        /// </summary>
        public string sessionCode { get; set; }
    }
}
