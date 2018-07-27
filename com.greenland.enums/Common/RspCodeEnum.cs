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
        #region 通用型返回码(0~999)

        [Description("请求成功")]
        RspCode_0000 = 0,

        [Description("请求失败")]
        RspCode_0001 = 1,

        #endregion

        #region 后台业务型返回码(1000~5000)

        [Description("登录失败，请检查用户名密码")]
        RspCode_1000 = 1000

        #endregion

    }
}
