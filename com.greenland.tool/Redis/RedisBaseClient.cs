/**
* 命名空间: com.greenland.tool.Redis
*
* 功 能： N/A
* 类 名： Class1
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/31 13:52:09 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.Redis
{
    public class RedisBaseClient
    {
        //配置文件
        protected RedisConnectionParameter configuration;

        //通信socket
        private Socket socket;

        //接收字节数组
        private byte[] ReceiveBuffer = new byte[100000];

        public RedisBaseClient(RedisConnectionParameter config)
        {
            configuration = config;
        }

        protected RedisBaseClient()
            : this(new RedisConnectionParameter())
        {
        }

        protected virtual void Connect()
        {
            if (socket != null && socket.Connected)
                return;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = configuration.NoDelaySocket
            };
            socket.Connect(configuration.Host, configuration.Port);
            if (socket.Connected)
            {
                //发送密码
                if (!string.IsNullOrEmpty(configuration.PassWord))
                {
                    var result = SendAuthPassword(configuration.PassWord);
                }
                return;
            }
            Close();
        }

        /// <summary>
        /// 关闭client
        /// </summary>
        protected virtual void Close()
        {
            socket.Disconnect(false);
            socket.Close();
        }

        private static object objectItem = new object();

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual string SendCommand(RedisCommandEnums command, params string[] args)
        {
            lock (objectItem)
            {

                //请求头部格式， *<number of arguments>\r\n
                const string headstr = "*{0}\r\n";
                //参数信息       $<number of bytes of argument N>\r\n<argument data>\r\n
                const string bulkstr = "${0}\r\n{1}\r\n";

                var sb = new StringBuilder();
                sb.AppendFormat(headstr, args.Length + 1);

                var cmd = command.ToString();
                sb.AppendFormat(bulkstr, cmd.Length, cmd);

                foreach (var arg in args)
                {
                    sb.AppendFormat(bulkstr, arg.Length, arg);
                }
                byte[] c = Encoding.UTF8.GetBytes(sb.ToString());
                try
                {
                    Connect();
                    socket.Send(c);

                    socket.Receive(ReceiveBuffer);
                    //Close();
                    return ReadData();
                }
                catch (SocketException e)
                {
                    //Close();
                }
            }
            return null;
        }

        public virtual string SendAuthPassword(params string[] args)
        {
            //请求头部格式， *<number of arguments>\r\n
            const string headstr = "*{0}\r\n";
            //参数信息       $<number of bytes of argument N>\r\n<argument data>\r\n
            const string bulkstr = "${0}\r\n{1}\r\n";

            var sb = new StringBuilder();
            sb.AppendFormat(headstr, args.Length + 1);

            var cmd = RedisCommandEnums.AUTH.ToString();
            sb.AppendFormat(bulkstr, cmd.Length, cmd);

            foreach (var arg in args)
            {
                sb.AppendFormat(bulkstr, arg.Length, arg);
            }
            byte[] c = Encoding.UTF8.GetBytes(sb.ToString());
            try
            {
                socket.Send(c);
                socket.Receive(ReceiveBuffer);
                return ReadData();
            }
            catch (SocketException e)
            {
                //Close();
            }
            return null;
        }

        private string ReadData()
        {
            var data = Encoding.UTF8.GetString(ReceiveBuffer);
            char c = data[0];
            //错误消息检查。
            if (c == '-') //异常处理。
                throw new Exception(data);
            //状态回复。
            if (c == '+')
                return data;
            return data;
        }

        public string StringGet(string key)
        {
            var result = SendCommand(RedisCommandEnums.GET, key);
            var reuslts = result.Split('\n');
            if (reuslts.Length >= 2)
            {
                return reuslts[1].TrimEnd('\r');
            }

            return string.Empty;
        }

        public bool StringSet(string key, string value)
        {
            var result = SendCommand(RedisCommandEnums.SET, key, value);
            if (result.StartsWith("+OK"))
                return true;
            return false;
        }

        public bool KeyExists(string key)
        {
            var result = SendCommand(RedisCommandEnums.EXISTS, key);
            if (result.StartsWith(":1"))
                return true;
            return false;
        }

        public bool KeyDelete(string key)
        {
            var result = SendCommand(RedisCommandEnums.DEL, key);
            if (result.StartsWith(":1"))
                return true;
            return false;
        }

        /// <summary>
        /// 生存时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public bool KeyExpire(string key, int seconds)
        {
            var result = SendCommand(RedisCommandEnums.EXPIRE, new string[] { key, seconds.ToString() });
            if (result.StartsWith(":1"))
                return true;
            return false;
        }
    }
}
