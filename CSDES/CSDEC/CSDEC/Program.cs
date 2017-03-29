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
            string de = ToDecrypt("4z8BwworyHQ =", "IccoWeb!@#");
            Console.WriteLine(de);
            Console.ReadLine();
        }
    }
}
