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

        public string SearchKey { get; set; }

        public string FunctionName { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }

        public int BizRspCode { get; set; }

        public BizException()
        {

        }

        public BizException(string searchKey)
        {
            SearchKey = string.IsNullOrWhiteSpace(searchKey) ? "BizException" : searchKey;
            FunctionName = "Common";
        }

        public BizException(string searchKey,string functionName)
        {
            SearchKey = string.IsNullOrWhiteSpace(searchKey) ? "BizException" : searchKey;
            FunctionName = functionName;
        }

        public BizException(string searchKey,string functionName,string message, int bizRspCode,string input = "",string output ="") : base(message)
        {
            SearchKey = string.IsNullOrWhiteSpace(searchKey) ? "BizException" : searchKey;
            FunctionName = functionName;
            BizRspCode = bizRspCode;
            Input = input;
            Output = output;
        }

        public BizException(string message, Exception innerException,string searchKey) : base(message, innerException)
        {
            SearchKey = string.IsNullOrWhiteSpace(searchKey) ? "BizException" : searchKey;
            exception = innerException;
        }
    }
}
