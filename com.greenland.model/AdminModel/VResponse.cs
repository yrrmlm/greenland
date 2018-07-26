

using com.greenland.enums.Common;
using com.greenland.tool.Extension;
/**
* 命名空间: com.greenland.model.AdminModel
*
* 功 能： N/A
* 类 名： VResponse
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/18 18:15:27 liumin 初版
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
    public class VResponse
    {
        public VResponse()
        {
            header = new VHeader();
        }
        public VHeader header { get; set; }
        public dynamic body { get; set; }
    }

    public class VHeader
    {
        public VHeader()
        {
            rspCode = (int)RspCodeEnum.RspCode_0000;
            rspDesc = RspCodeEnum.RspCode_0000.GetEnumDesc();
        }

        public int rspCode { get; set; }

        public string rspDesc { get; set; }
    }
}
