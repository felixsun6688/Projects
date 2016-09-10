using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AorangiPeak.Common.Utility
{
    public sealed class EncryptUtils
    {
        #region Base64 encryption and eecryption

        public static string Base64Encrypt(string input)
        {
            return Base64Encrypt(input, new UTF8Encoding());
        }

        public static string Base64Encrypt(string input, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(input));
        }

        public static string Base64Decrypt(string input)
        {
            return Base64Decrypt(input, new UTF8Encoding());
        }

        public static string Base64Decrypt(string input, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(input));
        }
        #endregion

        #region DES encryption and eecryption

        public static string DESEncrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string DESDecrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
        #endregion

        #region MD5 encryption and eecryption

        public static string MD5Encrypt(string input)
        {
            return MD5Encrypt(input, new UTF8Encoding());
        }

        public static string MD5Encrypt(string input, Encoding encode)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(encode.GetBytes(input));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }

        public static string MD5Encrypt(Stream stream)
        {
            MD5 md5serv = MD5CryptoServiceProvider.Create();
            byte[] buffer = md5serv.ComputeHash(stream);
            StringBuilder sb = new StringBuilder();
            foreach (byte var in buffer)
                sb.Append(var.ToString("x2"));
            return sb.ToString();
        }

        public static string MD5Encrypt16(string input, Encoding encode)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string result = BitConverter.ToString(md5.ComputeHash(encode.GetBytes(input)), 4, 8);
            result = result.Replace("-", "");
            return result;
        }
        #endregion

        #region 3DES encryption and eecryption

        public static string DES3Encrypt(string data, string key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.Mode = CipherMode.CBC;
            DES.Padding = PaddingMode.PKCS7;

            ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(data);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static string DES3Decrypt(string data, string key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.Mode = CipherMode.CBC;
            DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(data);
                result = ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
    }
}
