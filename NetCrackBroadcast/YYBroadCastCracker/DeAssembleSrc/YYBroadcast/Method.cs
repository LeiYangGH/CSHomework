using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
namespace YYBroadcast
{
    internal class Method
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr childAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        public static List<IntPtr> GetWindowEX(IntPtr hwndDesktop)
        {
            List<IntPtr> list = new List<IntPtr>();
            bool flag = true;
            IntPtr intPtr = IntPtr.Zero;
            while (flag)
            {
                intPtr = Method.FindWindowEx(hwndDesktop, intPtr, "QWidget", null);
                if (intPtr != IntPtr.Zero)
                {
                    list.Add(intPtr);
                }
                else
                {
                    flag = false;
                }
                //Thread.Sleep(100);
            }
            return list;
        }


        private static Encoding BestEncodingForCurrentSystem()
        {
            //if (Constants.BestEncodingForCurrentSystem == null)
            //{

            //    CultureInfo ci = CultureInfo.InstalledUICulture;
            //    string cultureEngName = ci.EnglishName;
            //    string filenae = Path.Combine(Environment.CurrentDirectory, "test.txt");
            //    File.WriteAllText(filenae, cultureEngName);
            //    if (cultureEngName.Contains("Simplif"))
            //        Constants.BestEncodingForCurrentSystem = Encoding.Default;
            //    else if (cultureEngName.Contains("Traditional"))
            //        Constants.BestEncodingForCurrentSystem = Encoding.GetEncoding("Big5");
            //    else
            //        Constants.BestEncodingForCurrentSystem = Encoding.UTF8;
            //}
            //return Constants.BestEncodingForCurrentSystem;
            return Encoding.GetEncoding("gb2312");
        }
        public static void InputBroadcastContent(string str, IntPtr hwnd)
        {
            foreach (string line in str.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                byte[] bytes = BestEncodingForCurrentSystem().GetBytes(str);
                foreach (byte b in BestEncodingForCurrentSystem().GetBytes(line))
                    Method.SendMessage(hwnd, 258, (int)b, 0);
                Method.SendMessage(hwnd, 256, 13, 0);
            }
        }
        public static void ShowCursor(IntPtr hwnd)
        {
            int num = 400;
            int num2 = 200;
            Method.SendMessage(hwnd, 6, 1, 0);
            Method.SendMessage(hwnd, 513, 0, num + (num2 << 16));
            Method.SendMessage(hwnd, 514, 0, num + (num2 << 16));
        }
    }
}
