/**
* 命名空间: com.greenland.tool.Encryption.AES
*
* 功 能： N/A
* 类 名： AESHelper
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/27 15:36:52 liumin 初版
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

namespace com.greenland.tool.Encryption.AES
{
    /// <summary>
    /// AES 加密类
    /// </summary>
    public class AESHelper
    {
        private const string strRijnKey = "lm.yrrmlm.com==www.greenland.com";

        private static byte[] RijndaelIVValue
        {
            get
            {
                return new byte[] { 0x13, 0x33, 0x5D, 0x7F, 0x52, 0x29, 0x2C, 0x15, 0x3B, 0x51, 0x55, 0x23, 0x4F, 0x19, 0x36, 0x3D };
            }
        }

        #region AES加密算法

        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="strRijnKey">密钥，必须为128位、192位或256位，默认选用128位</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public static string AESEncryptToString(string plainText, string strRijnKey = strRijnKey)
        {
            return Convert.ToBase64String(AESEncrypt(plainText, strRijnKey));
        }

        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="strRijnKey">密钥，必须为128位、192位或256位，默认选用128位</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public static byte[] AESEncrypt(string plainText, string strRijnKey)
        {
            byte[] rijnKey = Encoding.UTF8.GetBytes(strRijnKey);
            byte[] rijnIV = RijndaelIVValue;
            return AESEncrypt(plainText, rijnKey, rijnIV);
        }
       
        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="strRijnKey">密钥，必须为128位、192位或256位，默认选用128位</param>
        ///  <param name="strRijnIV">向量</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public static byte[] AESEncrypt(string plainText, string strRijnKey, string strRijnIV)
        {
            byte[] rijnKey = Encoding.UTF8.GetBytes(strRijnKey);
            byte[] rijnIV = Encoding.UTF8.GetBytes(strRijnIV);
            return AESEncrypt(plainText, rijnKey, rijnIV);
        }

        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="rijnKey">密钥字节数组，必须为128位、192位或256位，默认选用128位</param>
        /// <param name="rijnIV">密钥初始化向量字节数组</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public static byte[] AESEncrypt(string plainText, byte[] rijnKey, byte[] rijnIV)
        {
            SymmetricAlgorithm rijndael = null;
            MemoryStream memStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                rijndael = Rijndael.Create();
                if (string.IsNullOrEmpty(plainText))
                {
                    plainText = string.Empty;
                }
                byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);//得到需要加密的字节数组	
                //设置密钥及密钥向量
                rijndael.Key = rijnKey;
                rijndael.IV = rijnIV;
                memStream = new MemoryStream();
                cryptoStream = new CryptoStream(memStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherBytes = memStream.ToArray();//得到加密后的字节数组

                return cipherBytes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (rijndael != null) rijndael.Clear();

                if (memStream != null)
                {
                    memStream.Flush();
                    memStream.Close();
                }

                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                }
            }
        }
        #endregion

        #region AES解密算法

        /// <summary>
        /// AES解密算法
        /// </summary>
        /// <param name="plantText">密文字符</param>
        /// <param name="strRijnKey">密钥，必须为128位、192位或256位，默认选用128位</param>
        /// <returns>返回解密后的字符串</returns>
        public static string AESDecrypt(string plantText, string strRijnKey = strRijnKey)
        {
            byte[] rijnKey = Encoding.UTF8.GetBytes(strRijnKey);
            byte[] rijnIV = RijndaelIVValue;
            byte[] cipherText = Encoding.UTF8.GetBytes(plantText);
            return AESDecrypt(cipherText, rijnKey, rijnIV);
        }

        /// <summary>
        /// AES解密算法
        /// </summary>
        /// <param name="cipherText">密文字节数组</param>
        /// <param name="strRijnKey">密钥，必须为128位、192位或256位，默认选用128位</param>
        /// <returns>返回解密后的字符串</returns>
        public static string AESDecrypt(byte[] cipherText, string strRijnKey = strRijnKey)
        {
            byte[] rijnKey = Encoding.UTF8.GetBytes(strRijnKey);
            byte[] rijnIV = RijndaelIVValue;
            return AESDecrypt(cipherText, rijnKey, rijnIV);
        }

        /// <summary>
        /// AES解密算法
        /// </summary>
        /// <param name="cipherText">密文字节数组</param>
        /// <param name="rijnKey">密钥字节数组，必须为128位、192位或256位，默认选用128位</param>
        /// <param name="rijnIV">密钥初始化向量字节数组</param>
        /// <returns>返回解密后的字符串</returns>
        public static string AESDecrypt(byte[] cipherText, byte[] rijnKey, byte[] rijnIV)
        {
            SymmetricAlgorithm rijndael = null;
            MemoryStream memStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                rijndael = Rijndael.Create();
                rijndael.Key = rijnKey;
                rijndael.IV = rijnIV;

                memStream = new MemoryStream(cipherText);
                cryptoStream = new CryptoStream(memStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                string decryptedString = streamReader.ReadToEnd();

                return decryptedString;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (rijndael != null) rijndael.Clear();

                if (memStream != null)
                {
                    memStream.Flush();
                    memStream.Close();
                }

                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                }
            }
        }
        #endregion

        #region AES ECB模式算法

        /// <summary>
        /// AES加密 ECB模式算法
        /// </summary>
        /// <param name="toEncrypt">需要加密的原文</param>
        /// <param name="key">加密的密钥（128位，196位，256位）</param>
        /// <returns>加密的密文</returns>
        public static byte[] ECBEncrypt(string toEncrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.KeySize = 128;
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            return cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        }

        /// <summary>
        /// AES加密 ECB模式算法
        /// 转Base64
        /// </summary>
        /// <param name="plainText">需要加密的密文</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ECBEncriptyToBase64(string plainText, string key)
        {
            byte[] resultArray = ECBEncrypt(plainText, key);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// AES解密 ECB模式算法
        /// </summary>
        /// <param name="toDecrypt">需要解密的密文</param>
        /// <param name="key">解密的密钥（128位，196位，256位）</param>
        /// <returns>解密的原文</returns>
        public static string ECBDecrypt(string toDecrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.KeySize = 128;
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion 

    }
}
