

using com.greenland.tool.Redis;
/**
* 命名空间: com.greenland.adminservice.Cache
*
* 功 能： N/A
* 类 名： CommonCache
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/31 14:13:52 liumin 初版
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
    public class CommonCache
    {
        private const string ClassName = "CommonCache";

        /// <summary>
        /// 设置授权code
        /// </summary>
        /// <param name="loginKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetAuthCache(string loginKey, string value)
        {
            var cacheKey = CacheKeys.GetAuthCacheKey(loginKey, ClassName);
            return RedisHelper.Set(cacheKey, value);
        }

        /// <summary>
        /// 获取授权code
        /// </summary>
        /// <param name="loginKey"></param>
        /// <returns></returns>
        public static string GetAuthCache(string loginKey)
        {
            var cacheKey = CacheKeys.GetAuthCacheKey(loginKey, ClassName);
            return RedisHelper.GetString(cacheKey);
        }
    }
}
