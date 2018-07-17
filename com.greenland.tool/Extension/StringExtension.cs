

using Newtonsoft.Json;
/**
* 命名空间: com.greenland.tool.Extension
*
* 功 能： N/A
* 类 名： 字符串扩展方法 
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 13:40:28 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace com.greenland.tool.Extension
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public static class StringExtension
    {
        #region 常量定义
        //数字
        private const string REGEX_NUMERIC = @"^[-]?\d+[.]?\d*$";
        //邮件
        private const string REGEX_EMAIL = @"^\w+([-+.]\w+)*@(\w+([-.]\w+)*\.)+([a-zA-Z]+)+$";
        //中文字符
        private const string REGEX_CHINESE_CHARACTER = @"^[\u4e00-\u9fa5]{0,}$";
        #endregion

        /// <summary>
        /// 判断一个字符串是否为数字
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是合法数字，false: 输入字符串不是合法数字，空字符串返回false</returns>
        public static bool IsNumeric(this string str)
        {
            if (str == null) return false;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            str = str.Replace(",", String.Empty);
            Regex regNum = new Regex(REGEX_NUMERIC);
            return regNum.IsMatch(str);
        }

        /// <summary>
        /// 判断一个字符串是否为邮件
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是合法邮件地址，false：输入字符串不是合法邮件地址，空字符串返回false</returns>
        public static bool IsEmail(this string str)
        {
            if (str == null) return false;
            Regex regex = new Regex(REGEX_EMAIL, RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为小数
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是Decimal类型，false: 输入字符串不是Decimal类型，空字符串返回false</returns>
        public static bool IsDecimal(this string str)
        {
            if (str == null) return false;
            decimal decimalValue;
            return decimal.TryParse(str, out decimalValue);
        }

        /// <summary>
        /// 判断一个字符串是否全部为中文字符
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是中文字符，false: 输入字符串不是中文字符，空字符串返回true</returns>
        public static bool IsChineseCharacter(this string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, REGEX_CHINESE_CHARACTER);
        }

        /// <summary>
        /// 判断一个字符串是否为时间日期格式
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是时间日期格式，false: 输入字符串不是时间日期格式，空字符串返回false</returns>
        public static bool IsDateTime(this string str)
        {
            if (str == null) return false;
            DateTime dateTimeValue;
            return DateTime.TryParse(str, out dateTimeValue);
        }

        /// <summary>
        /// 判断一个字符串是否为8位无符号整数
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是无符号整数，false: 输入字符串不是无符号整数，空字符串返回false</returns>
        public static bool IsByte(this string str)
        {
            if (str == null) return false;
            byte byteData;
            return Byte.TryParse(str, out byteData);
        }

        /// <summary>
        /// 判断一个字符串是否为短整型整数
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是短整型整数，false: 输入字符串不是短整型整数，空字符串返回false</returns>
        public static bool IsInt16(this string str)
        {
            if (str == null) return false;
            short int16Data;
            return Int16.TryParse(str, out int16Data);
        }

        /// <summary>
        /// 判断一个字符串是否为整数
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是32位整数，false: 输入字符串不是32位整数，空字符串返回false</returns>
        public static bool IsInt32(this string str)
        {
            if (str == null) return false;
            int int32Data;
            return Int32.TryParse(str, out int32Data);
        }

        /// <summary>
        /// 判断一个字符串是否为长整数
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是64位整数，false: 输入字符串不是64位整数，空字符串返回false</returns>
        public static bool IsInt64(this string str)
        {
            if (str == null) return false;
            long longData;
            return Int64.TryParse(str, out longData);
        }

        /// <summary>
        /// 判断一个字符串是否为字母加数字
        /// Regex("[a-zA-Z0-9]?"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWordAndNum(this string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9]?");
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为手机号码
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是合法的手机号码，false: 输入字符串不是合法的手机号码，空字符串返回false</returns>
        public static bool IsMobileNum(this string str)
        {
            if (str == null) return false;
            Regex regex = new Regex(@"^(13[0-9]|15[0-9]|18[0-9]|145|147|149|166|198|199|17[0-9])\d{8}$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为电话号码
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是合法的电话号码，false: 输入字符串不是合法的电话号码，空字符串返回false</returns>
        public static bool IsPhoneNum(this string str)
        {
            if (str == null) return false;
            Regex regex = new Regex(@"^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为网址
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是合法的网址，false: 输入字符串不是合法的网址，空字符串返回false</returns>
        public static bool IsUrl(this string str)
        {
            if (str == null) return false;
            Regex regex = new Regex(@"(http://)?([\w-]+\.)*[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为IP地址
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true: 输入字符串是合法的IP地址，false: 输入字符串不是合法的IP地址，空字符串返回false</returns>
        public static bool IsIp(this string str)
        {
            if (str == null) return false;
            Regex regex = new Regex(@"^(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1})).(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1})).(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1})).(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1}))$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为null或者空字符串
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns>true: 空或者空字符串,false:不为空或者空字符串</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 判断一个字符串是否为null或者空白字符
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns>true: 空或者空字符串,false:不为空或者空白字符</returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 判断是否为字母
        /// </summary>
        /// <param name="str">要校验的字符串</param>
        /// <returns></returns>
        public static bool IsLetters(this string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"^[a-zA-Z]");
        }

        /// <summary>
        /// 判断是否是英文名
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns></returns>
        public static bool IsEnglishName(this string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"^[a-zA-Z]{1,}/[a-zA-Z]{1,}");
        }

        /// <summary>
        /// 判断密码是否符合规则
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPassword(this string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"^[a-zA-Z0-9_]{6,18}$");
        }

        /// <summary>
        /// 判断一个字符串是否为身份证号码格式
        /// </summary>
        /// <param name="str">身份证号码</param>
        /// <returns>是否为身份证号码格式</returns>
        //public static bool IsIdCard(this string str)
        //{
        //    if (str == null) return false;
        //    string msg = string.Empty;
        //    return IdCardValidator.CheckCard(str, false, out msg);
        //}

        /// <summary>
        /// 护照号码验证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPassport(this string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"^1[45][0-9]{7}|G[0-9]{8}|P[0-9]{7}|S[0-9]{7,8}|D[0-9]+$");
        }


        /// <summary>
        /// 判断是否是合法的xml
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>true:合法的xml，false：非法的xml</returns>
        //public static bool IsXml(this string str)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    return XmlHelper.IsXmlValid(str, ref xmlDoc);
        //}

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="str">需要处理字符串</param>
        /// <returns></returns>
        /// 全角空格为12288，半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        public static String ToDbc(this string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                {
                    c[i] = (char)(c[i] - 65248);
                }
            }
            return new string(c);
        }

        ///   <summary> 
        ///   去除HTML标记 
        ///   </summary> 
        //public static string TrimHtml(this string htmlString)
        //{
        //    if (htmlString.IsNullOrEmpty())
        //    {
        //        return string.Empty;
        //    }
        //    //删除脚本 
        //    //Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);
        //    //Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*>[\s]*?</script>", "", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //    //删除HTML 
        //    htmlString = Regex.Replace(htmlString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        //    //htmlString = Regex.Replace(htmlString, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"-->", "", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"<!--.*", "", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        //    htmlString = Regex.Replace(htmlString, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        //    htmlString = HttpUtility.HtmlDecode(htmlString).Trim();

        //    return htmlString;
        //}

        /// <summary>
        /// 将Json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="str">Json字符串</param>
        /// <returns>反序列化后的实体</returns>
        public static T ToEntity<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// 字符串转整型，无法转换返回0
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的整数</returns>
        public static int ToDecimalToInt(this string str)
        {
            return str.ToInt(0);
        }

        /// <summary>
        /// 字符串转整型
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换后的整数</returns>
        public static int ToInt(this string str, int defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defaultValue;
            }

            int value = defaultValue;

            if (int.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                try
                {
                    value = Convert.ToInt32(str.ToDecimal());
                }
                catch (Exception)
                {

                    value = defaultValue;
                }

            }
            return value;
        }
        /// <summary>
        /// 字符串转长整型
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换后的整数</returns>
        public static long ToLong(this string str, long defaultValue)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defaultValue;
            }

            long value = defaultValue;

            if (long.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                try
                {
                    value = Convert.ToInt64(str.ToDecimal());
                }
                catch (Exception)
                {

                    value = defaultValue;
                }

            }
            return value;
        }

        /// <summary>
        /// 字符串转整型，无法转换返回null
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的整数</returns>
        public static int? ToNullableInt(this string str)
        {
            int value = 0;
            if (int.TryParse(str, out value))
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 字符串转日期类型，无法转换返回DateTime.Now
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的日期</returns>
        public static DateTime ToDateTime(this string str)
        {
            return str.ToDateTime(DateTime.Now);
        }

        /// <summary>
        /// 字符串转日期类型
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换后的日期</returns>
        public static DateTime ToDateTime(this string str, DateTime defaultValue)
        {
            DateTime value = defaultValue;
            if (DateTime.TryParse(str, out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 字符串转日期类型，无法转换返回null
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的日期</returns>
        public static DateTime? ToNullableDateTime(this string str)
        {
            DateTime value = DateTime.Now;
            if (DateTime.TryParse(str, out value))
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 字符串转布尔类型，默认为false
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的布尔类型</returns>
        public static bool ToBoolean(this string str)
        {
            bool value = false;
            if (bool.TryParse(str, out value))
            {
                return value;
            }
            return false;
        }

        /// <summary>
        /// 字符串转小数，默认为0.0
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的小数</returns>
        public static decimal ToDecimal(this string str)
        {
            decimal value = new decimal(0);
            if (string.IsNullOrEmpty(str))
                return value;

            if (decimal.TryParse(str, out value))
            {
                return value;
            }
            return new decimal(0);
        }

        /// <summary>
        /// 字符串转小数，默认为0.0
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的小数</returns>
        public static decimal ToDecimal(this string str, decimal defaultValue)
        {
            decimal value = defaultValue;
            if (decimal.TryParse(str, out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 字符串转双精度型，默认为0.0
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>转换后的双精度值</returns>
        public static double ToDouble(this string str)
        {
            double value = 0;
            if (double.TryParse(str, out value))
            {
                return value;
            }
            return 0;
        }

        /// <summary>
        /// 根据身份证号获取生日
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns>0:女,1:男,-1:不是合法的身份证号</returns>
        //public static DateTime GetBirthday(this string idCardNo)
        //{
        //    return IdCardValidator.GetBirthday(idCardNo);
        //}

        /// <summary>
        /// 根据身份证号获取性别
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns>0:女,1:男,-1:处理失败</returns>
        //public static int GetGender(this string idCardNo)
        //{
        //    return IdCardValidator.GetGender(idCardNo);
        //}

        #region UNICODE字符转为中文
        /// <summary>
        /// UNICODE字符转为中文
        /// </summary>
        /// <param name="unicodeString"></param>
        /// <returns></returns>
        public static string ToChineseFromUnicode(this string unicodeString)
        {
            if (string.IsNullOrEmpty(unicodeString))
                return string.Empty;

            string outStr = unicodeString;

            Regex re = new Regex("\\\\u[0123456789abcdef]{4}", RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(unicodeString);
            foreach (Match ma in mc)
            {
                outStr = outStr.Replace(ma.Value, ConverUnicodeStringToChar(ma.Value).ToString());
            }
            return outStr;
        }

        private static char ConverUnicodeStringToChar(string str)
        {
            char outStr = Char.MinValue;
            outStr = (char)int.Parse(str.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            return outStr;
        }
        #endregion

        /// <summary>
        /// 汉字转换成全拼的拼音
        /// </summary>
        /// <param name="Chstr">汉字字符串</param>
        /// <returns>转换后的拼音字符串</returns>
        public static string ToPinYin(this string str)
        {
            //定义拼音区编码数组
            int[] getValue = new int[]
      {
          -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
          -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
          -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
          -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
          -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
          -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
          -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
          -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
          -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
          -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
          -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
          -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
          -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
          -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
          -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
          -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
          -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
          -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
          -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
          -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
          -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
          -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
          -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
          -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
          -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
          -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
          -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
          -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
          -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
          -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
          -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
          -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
          -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
      };
            //定义拼音数组
            string[] getName = new string[]
      {
          "A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
          "Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
          "Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
          "Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
          "Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
          "Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
          "Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
          "Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
          "Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
          "Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
          "Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
          "Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
          "Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
          "La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
          "Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
          "Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
          "Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
          "Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
          "Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
          "Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
          "Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
          "Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
          "Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
          "Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
          "Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
          "Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
          "Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
          "Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
          "Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
          "Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
          "Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
          "Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
          "Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
     };

            Regex reg = new Regex("^[\u4e00-\u9fa5]$");//验证是否输入汉字
            byte[] arr = new byte[2];
            string pystr = "";
            int asc = 0, M1 = 0, M2 = 0;
            char[] mChar = str.ToCharArray();//获取汉字对应的字符数组
            for (int j = 0; j < mChar.Length; j++)
            {
                //如果输入的是汉字
                if (reg.IsMatch(mChar[j].ToString()))
                {
                    arr = System.Text.Encoding.Default.GetBytes(mChar[j].ToString());
                    M1 = (short)(arr[0]);
                    M2 = (short)(arr[1]);
                    asc = M1 * 256 + M2 - 65536;
                    if (asc > 0 && asc < 160)
                    {
                        pystr += mChar[j];
                    }
                    else
                    {
                        switch (asc)
                        {
                            case -9254:
                                pystr += "Zhen"; break;
                            case -8985:
                                pystr += "Qian"; break;
                            case -5463:
                                pystr += "Jia"; break;
                            case -8274:
                                pystr += "Ge"; break;
                            case -5448:
                                pystr += "Ga"; break;
                            case -5447:
                                pystr += "La"; break;
                            case -4649:
                                pystr += "Chen"; break;
                            case -5436:
                                pystr += "Mao"; break;
                            case -5213:
                                pystr += "Mao"; break;
                            case -3597:
                                pystr += "Die"; break;
                            case -5659:
                                pystr += "Tian"; break;
                            default:
                                for (int i = (getValue.Length - 1); i >= 0; i--)
                                {
                                    if (getValue[i] <= asc)//判断汉字的拼音区编码是否在指定范围内
                                    {
                                        pystr += getName[i];//如果不超出范围则获取对应的拼音
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
                else//如果不是汉字
                {
                    pystr += mChar[j].ToString();//如果不是汉字则返回
                }
            }
            return pystr;//返回获取到的汉字拼音
        }

        /// <summary> 
        /// 分析用户请求是否正常 
        /// </summary> 
        /// <param name="str">传入用户提交数据 </param> 
        /// <returns>返回是否含有SQL注入式攻击代码 </returns> 
        public static bool ContainSqlKeyword(this string str)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    string sqlKeywords =
                        "select|exec|insert|delete|update|master|truncate|declare|cast|drop|hex|unhex|waitfor delay|xp_|sp_|sysdatabases|char(|0x|order by";

                    string[] keywordArray = sqlKeywords.Split('|');
                    foreach (string keyword in keywordArray)
                    {
                        if (str.ToLower().IndexOf(keyword + " ") >= 0)
                        {
                            returnValue = true;
                            break;
                        }
                        else if (str.ToLower().IndexOf(keyword) >= 0)
                        {
                            returnValue = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

        /// <summary>
        /// 返回请求参数的前n个固定长度
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string FixedLength(this string input, int length)
        {
            if (input.Trim().Length > length)
                return input.Substring(0, length);
            return input;
        }

        /// <summary>
        /// 返回请求参数的前n个固定长度
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string FixedRightLength(this string input, int length)
        {
            var strLength = input.Trim().Length;
            if (strLength > length)
                return input.Substring(strLength - length, length);
            return input;
        }

        public static string GetSexName(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "男";
            if (input.Trim().Length > 0)
            {
                var lastCode = input.Trim().Substring(input.Trim().Length - 1, 1);
                if (lastCode.ToInt() % 2 == 0)
                    return "女";
            }
            return "男";
        }

        public static string ToClientPrice(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            if (input.IndexOf('.') < 0)
            {
                return input;
            }
            else
            {
                return input.TrimEnd('0').TrimEnd('.');
            }

        }

        public static string ToDecimalPrice(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            if (input.IndexOf('.') == 0)
            {
                return input.Insert(0, "0");
            }
            else
            {
                return input;
            }

        }


        /// <summary>
        /// 对对象执行Json序列化
        /// </summary>
        /// <param name="obj">待序列化的对象</param>
        /// <returns>序列化后的Json字符串</returns>
        public static T ToJson<T>(this string obj)
        {
            try
            {
                if (obj.IsNullOrEmpty())
                {
                    return default(T);
                }
                return JsonConvert.DeserializeObject<T>(obj);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="v">处理数据</param>
        /// <param name="x">保留位数</param>
        /// <returns></returns>
        public static double Round(this double v, int x)
        {
            bool isNegative = false;
            //如果是负数
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }

            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            double Int = Math.Round(v * IValue + 0.5, 0);
            v = Int / IValue;

            if (isNegative)
            {
                v = -v;
            }

            return v;
        }

        /// <summary>
        /// 字符串转整型
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换后的整数</returns>
        public static Guid ToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Guid.Empty;
            }

            var value = Guid.Empty;
            if (Guid.TryParse(str, out value))
            {
                return value;
            }

            return Guid.Empty;
        }
    }
}
