/**
* 命名空间: com.greenland.adminservice.Cache
*
* 功 能： N/A
* 类 名： CacheKeys
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/31 14:14:08 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.adminservice.Cache
{
    public class CacheKeys
    {
        public const string Key_Prefix = "gl";

        #region common

        public static string GetAuthCacheKey(string loginKey,string className)
        {
            return string.Format("{0}_{1}_{2}", Key_Prefix, className, loginKey);
        }

        #endregion
    }
}
