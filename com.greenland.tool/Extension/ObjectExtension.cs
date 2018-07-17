/**
* 命名空间: com.greenland.tool.Extension
*
* 功 能： 对象扩展类
* 类 名： Class1
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 13:39:36 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.Extension
{
    public static class ObjectExtension
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            return obj == null || string.IsNullOrEmpty(obj.ToString());
        }

        public static string ToStringEx(this object obj)
        {
            if (obj.IsNullOrEmpty())
            {
                return string.Empty;
            }
            return obj.ToString();
        }

        /// <summary>
        /// 对象转整型,默认为 int32
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换后的整数</returns>
        public static int ToInt(this object obj, int defaultValue = 0)
        {
            if (obj == null)
                return defaultValue;
            if (obj.GetType().IsEnum)
            {
                return (int)obj;
            }
            return StringExtension.ToInt(obj.ToString(), defaultValue);
        }
        /// <summary>
        /// 对象转长整型,默认为 int64
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换后的整数</returns>
        public static long ToLong(this object obj, long defaultValue = 0)
        {
            if (obj == null)
                return defaultValue;
            if (obj.GetType().IsEnum)
            {
                return (int)obj;
            }
            return StringExtension.ToLong(obj.ToString(), defaultValue);
        }

        public static DateTime ToDateTime(this object obj)
        {
            return StringExtension.ToDateTime(obj.ToString());
        }

        public static string ByteToString(this object data)
        {
            return Encoding.UTF8.GetString((byte[])data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultDateTime">默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj, DateTime defaultDateTime)
        {
            if (obj == null)
                return defaultDateTime;
            return StringExtension.ToDateTime(obj.ToString(), defaultDateTime);
        }

        public static Decimal ToDecimal(this object obj)
        {
            decimal defaultValue = new decimal(0);
            if (obj == null)
                return defaultValue;
            return StringExtension.ToDecimal(obj.ToString());
        }

        public static bool ToBoolean(this object obj)
        {
            return ToBoolean(obj, false);
        }

        public static bool ToBoolean(this object obj, bool defaultValue)
        {
            bool value = false;
            if (bool.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return defaultValue;
        }
    }
}
