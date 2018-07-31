/**
* 命名空间: com.greenland.model.AdminModel
*
* 功 能： N/A
* 类 名： PageReq
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/18 18:27:32 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.model.AdminModel
{
    public class PageReq: BaseReq
    {
        public PageReq()
        {
            pageIndex = 1;
            pageSize = 10;
        }
        public int pageIndex { get; set; }

        public int pageSize { get; set; }
    }
}
