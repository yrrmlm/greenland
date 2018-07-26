/**
* 命名空间: com.greenland.enums.Common
*
* 功 能： N/A
* 类 名： RspCodeEnum
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/26 13:37:00 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.enums.Common
{
    public enum RspCodeEnum
    {
        [Description("请求成功")]
        RspCode_0000 = 0,

        [Description("请求失败")]
        RspCode_0001 = 1
    }
}
