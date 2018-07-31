/**
* 命名空间: com.greenland.tool.Redis
*
* 功 能： N/A
* 类 名： RedisConnectionParameter
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/31 13:54:02 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.Redis
{
    public class RedisConnectionParameter
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public string PassWord { get; set; }

        /// <summary>
        /// Socket 是否正在使用 Nagle 算法。
        /// </summary>
        public bool NoDelaySocket { get; set; }
    }
}
