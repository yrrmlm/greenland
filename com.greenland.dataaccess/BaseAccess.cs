/**
* 命名空间: com.greenland.dataaccess
*
* 功 能： N/A
* 类 名： BaseAccess
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 13:29:05 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.dataaccess
{
    public abstract class BaseAccess<T>
    {
        protected abstract T ConvertToEntity(DataRow dr);

        protected abstract List<T> ConvertToEntityList(DataTable dt);
    }
}
