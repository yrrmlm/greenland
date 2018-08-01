/**
* 命名空间: com.greenland.tool.BizException
*
* 功 能： N/A
* 类 名： BizException
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/8/1 16:59:37 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.BizException
{
    public class BizException : ApplicationException
    {
        private Exception exception;

        public BizException()
        {

        }

        public BizException(string message) : base(message)
        {
        }

        public BizException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
