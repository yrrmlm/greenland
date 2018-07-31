

using com.greenland.tool.Redis;
using Newtonsoft.Json;
/**
* 命名空间: com.greenland.tool.Redis
*
* 功 能： N/A
* 类 名： RedisHelper
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/31 13:55:18 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.Redis
{
    public class RedisHelper
    {
        private static object _redisObject = new object();

        /// <summary>
        /// 默认缓存失效时间
        /// </summary>
        private static TimeSpan _defaultTimeSpan = new TimeSpan(2, 0, 0);

        /// <summary>
        /// 缓存对象
        /// </summary>
        private static RedisBaseClient _dbInstance;

        private static RedisBaseClient DbInstance
        {
            get  //redis 使用单例
            {
                lock (_redisObject)
                {
                    if (_dbInstance == null)
                    {
                        RedisBaseClient redis = new RedisBaseClient(new RedisConnectionParameter
                        {
                            Host = "127.0.0.1",
                            Port = 6379,
                            PassWord = "lm@32351",
                            NoDelaySocket = false
                        });
                        _dbInstance = redis;
                    }
                    return _dbInstance;
                }
            }
        }

        private static string GetRedisString(string key)
        {
            try
            {
                var redisValue = DbInstance.StringGet(key);
                return redisValue ?? string.Empty;
            }
            catch (Exception err)
            {
                return string.Empty;
            }
        }

        private static bool SetRedisString(string key, string value, TimeSpan timeSpan)
        {
            try
            {
                if (DbInstance.StringSet(key, value))
                {
                    if (timeSpan.Seconds > 0)
                        DbInstance.KeyExpire(key, timeSpan.Seconds);
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private static bool SetRedisString(string key, int value, TimeSpan timeSpan)
        {
            return SetRedisString(key, value.ToString(), timeSpan);
        }

        /// <summary>
        /// 格式化Key
        /// 去除空格
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private static string FormatRedisKey(string keyName)
        {
            return keyName.Replace(" ", "");
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>(string key) where T : new()
        {
            try
            {

                if (!DbInstance.KeyExists(FormatRedisKey(key)))
                    return default(T);

                var value = GetRedisString(FormatRedisKey(key));
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获取缓存键对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            try
            {
                if (!DbInstance.KeyExists(FormatRedisKey(key)))
                    return string.Empty;

                return GetRedisString(FormatRedisKey(key));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 保存对象
        /// </summary> 
        /// <returns></returns>
        public static bool Set(string key, string content)
        {
            return SetRedisString(FormatRedisKey(key), content, _defaultTimeSpan);
        }

        /// <summary>
        /// 保存对象
        /// </summary> 
        /// <returns></returns>
        public static bool Set(string key, string content, TimeSpan timespan)
        {
            return SetRedisString(FormatRedisKey(key), content, timespan);

        }

        /// <summary>
        /// 保存对象
        /// </summary> 
        /// <returns></returns>
        public static bool Set(string key, int value)
        {
            return SetRedisString(FormatRedisKey(key), value, new TimeSpan(24, 0, 0));
        }

        /// <summary>
        /// 保存对象
        /// </summary> 
        /// <returns></returns>
        public static bool Set(string key, int value, TimeSpan timespan)
        {
            return SetRedisString(FormatRedisKey(key), value, timespan);
        }

        /// <summary>
        /// 保存对象
        /// </summary> 
        /// <returns></returns>
        public static bool Set<T>(string key, T entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            return SetRedisString(FormatRedisKey(key), content, new TimeSpan(24, 0, 0));
        }

        /// <summary>
        /// 保存对象
        /// </summary> 
        /// <returns></returns>
        public static bool Set<T>(string key, T entity, TimeSpan timespan)
        {
            var content = JsonConvert.SerializeObject(entity);
            return SetRedisString(FormatRedisKey(key), content, timespan);
        }

        /// <summary>
        /// 清空某个缓存键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Clear(string key)
        {
            try
            {
                if (DbInstance.KeyDelete(FormatRedisKey(key)))
                    return true;
                return false;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// 自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timespan"></param>
        /// <returns></returns>
        public static long InCrease(string key, TimeSpan timespan)
        {
            try
            {
                if (DbInstance.KeyExists(FormatRedisKey(key)))
                {
                    // return DbInstance.Incr(FormatRedisKey(key)); //默认步长为1, 超时无效
                    var value = GetRedisString(FormatRedisKey(key));
                    if (!string.IsNullOrEmpty(value))
                    {
                        var newValue = int.Parse(value) + 1;
                        SetRedisString(FormatRedisKey(key), newValue, timespan);
                        return newValue;
                    }
                }

                if (SetRedisString(FormatRedisKey(key), 1, timespan))
                    return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        ///// <summary>
        ///// 自增
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static long InCrease(string key)
        //{
        //    try
        //    {
        //        if (DbInstance.KeyExists(FormatRedisKey(key)))
        //            return DbInstance.StringIncrement(FormatRedisKey(key)); //默认步长为1

        //        if (SetRedisString(FormatRedisKey(key), 1, _defaultTimeSpan))
        //            return 1;
        //        return 0;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        ///// <summary>
        ///// 自减
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static long DeCrease(string key)
        //{
        //    try
        //    {
        //        if (DbInstance.KeyExists(FormatRedisKey(key)))
        //            return DbInstance.StringDecrement(FormatRedisKey(key)); //默认步长为1

        //        if (SetRedisString(FormatRedisKey(key), "1", _defaultTimeSpan))
        //            return 1;
        //        return 0;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        /// <summary>
        /// 清空DB
        /// </summary>
        /// <returns></returns>
        public static bool FlushDb()
        {
            if (DbInstance == null)
                return false;

            return true;
        }
    }
}
