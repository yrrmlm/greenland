/**
* 命名空间: com.greenland.tool.Encryption.SHA
*
* 功 能： N/A
* 类 名： SHA1Helper
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/30 15:45:21 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.Encryption.SHA
{
    public class SHA1Helper
    {
        #region SHA1加密

        /// <summary>
        /// 使用缺省密钥给字符串加密
        /// </summary>
        /// <param name="Source_String"></param>
        /// <returns></returns>
        public string SHA1_Encrypt(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();

            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }

        /// <summary>
        /// 使用缺省密钥给字符串加密
        /// </summary>
        /// <param name="Source_String"></param>
        /// <param name="encoding">默认UTF8</param>
        /// <returns></returns>
        public static string SHA1_Encrypt(string Source_String, Encoding encoding)
        {
            byte[] StrRes = encoding.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();

            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }

        /// <summary>
        /// 使用给定密钥加密
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string Encryption(string original, string key)
        {
            return Encryption(original, key);
        }

        /// <summary>
        /// 使用缺省密钥加密文件
        /// </summary>
        /// <param name="m_InFilePath"></param>
        /// <param name="m_OutFilePath"></param>
        public void DesEncrypt(string m_InFilePath, string m_OutFilePath)
        {
            try
            {
                FileStream fin = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                byte[] bin = new byte[100]; //这中间的加密存储。
                long rdlen = 0;
                long totlen = fin.Length;
                int len;
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(), CryptoStreamMode.Write);

                //读取输入文件，然后加密并写入到输出文件。
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
                encStream.Close();
                fout.Close();
                fin.Close();


            }
            catch
            {
                //MessageBox.Show(error.Message.ToString());

            }
        }

        /// <summary>
        /// 使用给定密钥加密文件
        /// </summary>
        /// <param name="m_InFilePath">Encrypt file path</param>
        /// <param name="m_OutFilePath">output file</param>
        /// <param name="strEncrKey"></param>
        public void DesEncrypt(string m_InFilePath, string m_OutFilePath, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                FileStream fin = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                byte[] bin = new byte[100]; //这中间的加密存储。
                long rdlen = 0;
                long totlen = fin.Length;
                int len;
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);

                //读取输入文件，然后加密并写入到输出文件。
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
                encStream.Close();
                fout.Close();
                fin.Close();


            }
            catch
            {
                //MessageBox.Show(error.Message.ToString());

            }
        }

        /// <summary>
        /// 生成sha1摘要
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        public static byte[] makeSHA1(byte[] original)
        {
            SHA1CryptoServiceProvider hashsha1 = new SHA1CryptoServiceProvider();
            byte[] keyhash = hashsha1.ComputeHash(original);
            hashsha1 = null;
            return keyhash;
        }

        #endregion
    }
}
