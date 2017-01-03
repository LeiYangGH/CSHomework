using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCComTransfer
{
    /// <summary>
    /// 自定义的日志类
    /// </summary>
    public class CLogWriter
    {
        private static CLogWriter mLogWriter = null;

        //两个线程锁，确保线程安全
        private static object _syncObject = new object();
        private static object _syncWriter = new object();

        //单例模式，确保只有一个日志读写实例在运行
        //http://baike.baidu.com/view/1859857.htm
        public static CLogWriter Instance
        {
            get
            {
                lock (_syncObject)
                {
                    if (mLogWriter == null)
                    {
                        mLogWriter = new CLogWriter();
                    }
                    return mLogWriter;
                }
            }
        }

        private System.IO.StreamWriter mFile = null;

        private int mLength = 0;

        #region 构造和析构
        private CLogWriter()
        {
            string s_filename = this.GetNewFileName();

            this.OpenLogFile(s_filename);
        }

        ~CLogWriter()
        {
            this.CloseLog();
        }
        #endregion

        //关闭文件
        public void CloseLog()
        {
            if (this.mFile != null)
            {
                try
                {
                    this.mFile.Close();
                }
                catch (Exception ex)
                {
                }
            }

            this.mFile = null;
        }

        #region 当前日志文件名
        private string mCurrentFileName = "";

        public string CurrentFileName
        {
            get
            {
                return this.mCurrentFileName;
            }
        }
        #endregion

        /// <summary>
        /// 取得一个新的文件名
        /// 通过日期构造日志文件名，目的是保证日志有序方便查找
        /// </summary>
        /// <returns></returns>
        private string GetNewFileName()
        {
            string s_path = System.AppDomain.CurrentDomain.BaseDirectory;

            if (System.IO.Directory.Exists(s_path + "\\Log"))
            {
            }
            else
            {
                System.IO.Directory.CreateDirectory(s_path + "\\Log");
            }

            string s_filename = s_path + "\\Log\\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";

            return s_filename;
        }

        //打开日志文件
        private int OpenLogFile(string s_filename)
        {

            if (this.mFile != null)
            {
                this.mFile.Close();
                this.mFile = null;
            }

            try
            {
                this.mFile = System.IO.File.CreateText(s_filename);
                mLength = 0;
            }
            catch (Exception ex)
            {
                return -1;
            }

            this.mCurrentFileName = s_filename;
            return 1;

        }

        //新建日志文件
        private void BeginNewLogFile()
        {
            string s_filename = GetNewFileName();

            this.OpenLogFile(s_filename);
        }
        #region 写入日志

        /// <summary>
        /// 写入日志信息
        /// 并附带上日期时间等信息
        /// </summary>
        /// <param name="s_msg">信息</param>
        public void WriteLog(string s_msg)
        {
            lock (_syncWriter)
            {
                string s_datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + s_msg;
                this.mFile.WriteLine(s_datetime);
                this.mFile.Flush();
                this.mLength += s_datetime.Length;
                if (this.mLength >= 1048576)
                {
                    this.BeginNewLogFile();
                }
            }
        }
        /// <summary>
        /// 把异常写入日志
        /// </summary>
        /// <param name="ex"></param>
        public void WriteLog(Exception ex)
        {
            lock (_syncWriter)
            {
                string s_datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   " + ex.ToString();

                this.mFile.WriteLine(s_datetime);
                this.mFile.Flush();
                this.mLength += s_datetime.Length;
                if (this.mLength >= 1048576)
                {
                    this.BeginNewLogFile();
                }
            }
        }
        #endregion

    }
}
