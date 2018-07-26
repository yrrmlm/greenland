/**
* 命名空间: com.greenland.model.AdminModel
*
* 功 能： N/A
* 类 名： PageRep
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/26 13:49:57 liumin 初版
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
    public class PageRep
    {
        public int curPage { get; set; }

        public int totalPage { get; set; }
    }
}
