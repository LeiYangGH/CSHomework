using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSGetWindowText
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        static extern int GetActiveWindow();

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        /// <summary>
        /// Returns a list of child windows
        /// </summary>
        /// <param name="parent">Parent of the windows to return</param>
        /// <returns>List of child windows</returns>
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="handle">Handle of the next window</param>
        /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            //if (list == null)
            //{
            //    throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            //}
            if (list != null)
                list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }

        /// <summary>
        /// Delegate for the EnumChildWindows method
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="parameter">Caller-defined variable; we use it for a pointer to our list</param>
        /// <returns>True to continue enumerating, false to bail.</returns>
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int RegisterWindowMessage(string lpString);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)] //
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam,
      int lparam);

        const int WM_GETTEXT = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;

        public static void RegisterControlforMessages()
        {
            RegisterWindowMessage("WM_GETTEXT");
        }
        public static string GetControlText(IntPtr hWnd)
        {

            StringBuilder title = new StringBuilder();

            // Get the size of the string required to hold the window title. 
            Int32 size = SendMessage((int)hWnd, WM_GETTEXTLENGTH, 0, 0).ToInt32();

            // If the return is 0, there is no title. 
            if (size > 0)
            {
                title = new StringBuilder(size + 1);

                SendMessage(hWnd, (int)WM_GETTEXT, title.Capacity, title);


            }
            return title.ToString();
        }

        static void TestA()
        {
            try
            {
                int h = GetForegroundWindow();
                StringBuilder b = new StringBuilder();
                GetWindowText(h, b, 256);
                string s = b.ToString();

                if (s.Trim().Length > 3)
                    Console.Write(b.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void TestB()
        {
            try
            {
                int h = GetForegroundWindow();
                List<IntPtr> lst = GetChildWindows((IntPtr)h);
                foreach (IntPtr p in lst)
                {
                    string s = GetControlText(p);
                    if (s.Trim().Length > 2)
                        Console.Write(s);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        //static void TestNotepad()
        //{
        //    try
        //    {
        //        //int h = GetForegroundWindow();
        //        int h = 0x30482;
        //        StringBuilder sb = new StringBuilder(65535);
        //        // needs to be big enough for the whole text
        //        SendMessage((IntPtr)h, WM_GETTEXT, sb.Length, sb);
        //        Console.WriteLine(sb.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        static void TestNotepad()
        {
            IntPtr hWnd = FindWindow("Notepad", null);
            Console.WriteLine("hWnd={0}", hWnd);
            IntPtr hEdit = FindWindowEx(hWnd, IntPtr.Zero, "Edit", null);
            Console.WriteLine("hEdit={0}", hEdit);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(255);  // or length from call
            SendMessage(hEdit, WM_GETTEXT, sb.Capacity, sb);
            string text = sb.ToString();
            Console.WriteLine(text);
        }

        static void EnumAllChild(IntPtr h, Action<IntPtr> act)
        {
            foreach (IntPtr ch in GetChildWindows(h))
            {
                act(ch);
                EnumAllChild(ch, act);
            }
        }


        static void TestTaskManager()
        {
            IntPtr hWnd = FindWindow("TaskManagerWindow", null);
            Console.WriteLine("hWnd={0}", hWnd);
            IntPtr hNativeHWNDHost = FindWindowEx(hWnd, IntPtr.Zero, "NativeHWNDHost", null);
            Console.WriteLine("hNativeHWNDHost={0}", hNativeHWNDHost.ToString("X"));
            //IntPtr hTmWindow = FindWindowEx(hNativeHWNDHost, IntPtr.Zero, "TmWindow", null);

            //Console.WriteLine("hTmWindow={0}", hTmWindow.ToString("X"));
            EnumAllChild(hWnd, new Action<IntPtr>((h) =>
             {
                 //System.Text.StringBuilder sb = new System.Text.StringBuilder(255);
                 //SendMessage(h, WM_GETTEXT, sb.Capacity, sb);
                 //string text = sb.ToString();
                 //Console.Write(text);


                 StringBuilder b = new StringBuilder();
                 GetWindowText((int)h, b, 256);
                 string s = b.ToString();
                 Console.Write(s);

                 //Console.WriteLine(h.ToString("X"));
             }));

            //List<IntPtr> lst = GetChildWindows((IntPtr)hNativeHWNDHost);
            //foreach (IntPtr p in lst)
            //{
            //    Console.WriteLine(p.ToString("X"));
            //}

            //Console.WriteLine();
            //System.Text.StringBuilder sb = new System.Text.StringBuilder(255);
            //SendMessage(hEdit, WM_GETTEXT, sb.Capacity, sb);
            //string text = sb.ToString();
            //Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("3秒...");
            Thread.Sleep(3000);
            Console.WriteLine("开始...");
            //TestNotepad();
            TestTaskManager();
            //while (true)
            //{
            //    //TestA();
            //    //TestB();
            //    //GetVIM();
            //    Thread.Sleep(500);
            //}
            Console.WriteLine("结束");
            Console.ReadLine();
        }
    }
}
