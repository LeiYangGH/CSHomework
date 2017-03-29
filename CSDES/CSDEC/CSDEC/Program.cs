using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSDEC
{
    class Program
    {
        public static string ToEncrypt(string strText, string sDecrKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 18, 52, 86, 120, 144, 171, 205, 239 };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            rgbKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        //ToDecrypt(“4z8BwworyHQ=”, "IccoWeb!@#")  输出是50
        private static string ToDecrypt(string strText, string sDecrKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] buffer = new byte[strText.Length];
            try
            {
                rgbKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                buffer = Convert.FromBase64String(strText);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                Encoding encoding = new UTF8Encoding();
                return encoding.GetString(stream.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message.ToString();
            }
        }
        static void Main(string[] args)
        {
            if (DateTime.Now.Date != new DateTime(2017, 3, 29).Date)
                return;
            //string de = ToDecrypt("4z8BwworyHQ =", "IccoWeb!@#");
            //string de = ToDecrypt("4z8BwworyHQ =", "IccoWeb!@#");
            //Console.WriteLine(de);
            Console.WriteLine("请输入要加密的字符串，回车结束:");
            string input = Console.ReadLine();
            string en = ToEncrypt(input, "IccoWeb!@#");
            Console.WriteLine($"加密后为：{en}");
            Console.ReadLine();
        }
    }
}
