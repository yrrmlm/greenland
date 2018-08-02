/**
* 命名空间: com.greenland.tool.Http
*
* 功 能： N/A
* 类 名： Class1
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/8/2 13:48:25 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace com.greenland.tool.Http
{
    public class IPHelper
    {
        public static string GetHostIP()
        {
            var hostIP = string.Empty;
            try
            {
                IPAddress[] ipArray;
                ipArray = Dns.GetHostAddresses(Dns.GetHostName());
                hostIP = ipArray.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            }
            catch
            {
                hostIP = "127.0.0.1";
            }

            return hostIP;
        }

        public static string GetRequestIP()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return userHostAddress;
        }
    }
}
