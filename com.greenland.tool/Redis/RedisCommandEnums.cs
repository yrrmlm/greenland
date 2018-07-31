/**
* 命名空间: com.greenland.tool.Redis
*
* 功 能： N/A
* 类 名： RedisCommandEnums
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/31 13:52:31 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.Redis
{
    public enum RedisCommandEnums
    {
        [Description("获取一个key的值")]
        GET, //获取一个key的值
        [Description("Redis信息")]
        INFO, //Redis信息。  
        [Description("添加一个值")]
        SET, //添加一个值
        [Description("设置过期时间")]
        EXPIRE, //设置过期时间
        [Description("标记一个事务块开始")]
        MULTI, //标记一个事务块开始
        [Description("执行所有 MULTI 之后发的命令")]
        EXEC, //执行所有 MULTI 之后发的命令
        [Description("自增,返回自增后的值")]
        INCR,//自增,返回自增后的值
        [Description("密码验证")]
        AUTH,
        [Description("是否存在")]
        EXISTS,
        [Description("删除Key")]
        DEL
    }
}
