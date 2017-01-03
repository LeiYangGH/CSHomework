using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO.Ports;
using System.Configuration;
using System.Threading;
using System.IO;
//*********************架构简述**********************************
//通过通读程序，发现这是一个Windows服务，也就是不带界面，在后台运行的程序。
//程序的目的大体是通过串口接收和发送信息，以控制某些硬件（从代码里写的中文来看是某些发光硬件）。
//程序员的水平一般，对很多C#的知识不够精通，写的代码显得凌乱，变量名不符合规范，还有大部分数据处理的代码可以简化和更可靠。
//具体的数据处理的写法正确与否，以及优化方法，必须要知道硬件的具体通信协议。这个在硬件说明书上应该有。
//日志类也写得不怎么样，没必要自己写个日志类，网上有开源的log4net等组件。
//要学习串口首先要有相应硬件，如果没有硬件得有串口模拟器（下载软件也行），但没硬件就不容易检验程序写得是否正确。
//***************************************************************
namespace WCComTransfer
{
    //https://msdn.microsoft.com/zh-cn/library/system.serviceprocess.servicebase(v=vs.110).aspx
    public partial class CWCComTransfer : ServiceBase
    {
        public CWCComTransfer()
        {
            InitializeComponent();
        }

        //定义两个串口，从变量名看一个是收，一个是发
        //https://msdn.microsoft.com/zh-cn/library/system.io.ports.serialport(v=vs.110).aspx
        private SerialPort mInPort = new SerialPort();
        private SerialPort mOutPort = new SerialPort();

        //接收端口号
        private int mInPortNumber = 1;
        //发送端口号
        private int mOutPortNumber = 2;
        //波特率2400为默认值
        private int mPortSpeed = 2400;
        //从变量名看是工作不工作的意思，但具体什么意思得看整个程序的功能
        private bool mIfWork = false;


        private EventWaitHandle mExitEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
        private EventWaitHandle mExitOkEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
        private Thread mThreadHandle = null;
        private List<RandPairs> lstRandPairs;

        //服务启动
        protected override void OnStart(string[] args)
        {
            //如果读取配置失败
            CLogWriter.Instance.WriteLog("读取配置文件");

            this.lstRandPairs = this.ReadRandPairs();

            if (LoadConfig() == false)
            {
                base.Stop();
            }

            //启动时候设置串口参数，并开启串口
            try
            {
                //串口名称
                this.mInPort.PortName = "Com" + this.mInPortNumber.ToString();
                CLogWriter.Instance.WriteLog(this.mInPort.PortName);
                //每个字节的标准数据位长度
                this.mInPort.DataBits = 8;
                //终止位
                this.mInPort.StopBits = StopBits.One;
                //奇偶校验位
                this.mInPort.Parity = Parity.None;
                //波特率
                this.mInPort.BaudRate = this.mPortSpeed;
                //打开串口
                this.mInPort.Open();

                //事件注册：表示当收到数据的时候，执行mInPort_DataReceived方法
                this.mInPort.DataReceived += new SerialDataReceivedEventHandler(mInPort_DataReceived);

                //和上面类似
                this.mOutPort.PortName = "Com" + this.mOutPortNumber.ToString();
                CLogWriter.Instance.WriteLog(this.mOutPort.PortName);
                this.mOutPort.BaudRate = this.mPortSpeed;
                this.mOutPort.DataBits = 8;
                this.mOutPort.StopBits = StopBits.One;
                this.mOutPort.Parity = Parity.None;
                this.mOutPort.Open();
                //从这句可以看出发送端口也会收到数据
                this.mOutPort.DataReceived += new SerialDataReceivedEventHandler(mOutPort_DataReceived);
            }
            catch (Exception ex)
            {
                CLogWriter.Instance.WriteLog("打开串口失败。");
                CLogWriter.Instance.WriteLog(ex);
            }

            CLogWriter.Instance.WriteLog("端口已打开。");
            //创建新的进程，执行MainThreadEntry方法
            this.mThreadHandle = new Thread(new ThreadStart(MainThreadEntry));
            this.mThreadHandle.Start();

            CLogWriter.Instance.WriteLog("服务已启动。");

        }

        private List<byte> mBuffer = new List<byte>();
        private bool mDataReceive = false;
        private decimal mLastYGSXP = 0;

        /// <summary>
        /// 处理数据（原来的注释，写得很模糊，和没注释没啥区别）
        /// 从代码可以看出一点业务逻辑：串口数据有一些段是数据，另一些段是控制数据，
        /// 具体得看硬件究竟起什么作用
        /// 这个函数是递归调用，从n_index++可以看出是从前往后依次遍历每个字节处理
        /// </summary>
        /// <param name="bt_data"></param>
        private void ProcessDataReceive(ref byte[] bt_data, ref int n_index)
        {
            if (this.mDataReceive == false)
            {
                if (n_index < bt_data.Length)
                {
                    if (bt_data[n_index] == 0x01)//似乎0x01是一个标志位
                    {
                        //收到数据
                        this.mDataReceive = true;

                        this.mBuffer.Clear();

                        this.mBuffer.Add(bt_data[n_index]);


                        n_index++;
                        CLogWriter.Instance.WriteLog("数据字节开始" + n_index.ToString());
                        //处理后续字节
                        this.ProcessDataReceive(ref bt_data, ref n_index);
                    }
                    else
                    {
                        this.mInPort.Write(new byte[] { bt_data[n_index] }, 0, 1);

                        CLogWriter.Instance.WriteLog("控制字符：INDEX=" + n_index.ToString() + ";内容=" + bt_data[n_index].ToString("X"));
                        n_index++;
                        this.ProcessDataReceive(ref bt_data, ref n_index);
                    }
                }
            }
            else
            {
                while (n_index < bt_data.Length)
                {
                    if (bt_data[n_index] == 0xff)
                    {
                        CLogWriter.Instance.WriteLog("数据字节结束" + n_index.ToString());

                        //数据的结束字符
                        this.mBuffer.Add(bt_data[n_index]);
                        n_index++;

                        //处理数据
                        try
                        {
                            this.ProcessDataMX();
                        }
                        catch (Exception ex)
                        {
                            CLogWriter.Instance.WriteLog("处理数据时发生错误。");
                            CLogWriter.Instance.WriteLog(ex);
                        }
                        //处理后续字节
                        this.ProcessDataReceive(ref bt_data, ref n_index);
                    }
                    else
                    {
                        //全部加到缓冲区
                        this.mBuffer.Add(bt_data[n_index]);
                        n_index++;
                    }
                }
            }
        }

        /// <summary>
        /// 进行描红并转发
        /// </summary>
        private void ProcessDataMX()
        {
            //取消数据模式
            this.mDataReceive = false;

            if (this.mBuffer.Count >= 31)
            {
                //长度为31,说明是长数据
                this.PutTestValue(this.mBuffer.ToArray());
            }
            else
            {
                //短的数据
                this.PutTestValue_2(this.mBuffer.ToArray());
            }

            this.mBuffer.Clear();
        }

        /// <summary>
        /// 短数据
        /// </summary>
        /// <param name="bt_arr"></param>
        public void PutTestValue_2(byte[] bt_arr)
        {
            int n_dg = (int)this.ParseValue(bt_arr, 1, 3);
            decimal dec_dgb = this.ParseValue(bt_arr, 4, 4);

            if (this.mLastYGSXP == 0)
            {
                this.mInPort.Write(bt_arr, 0, bt_arr.Length);
            }
            else
            {
                if (n_dg <= 0)
                {
                    n_dg = 60;
                }
                dec_dgb = System.Math.Round(((decimal)n_dg + this.mLastYGSXP) / (decimal)n_dg, 2);

                CLogWriter.Instance.WriteLog("修正后的远光灯高比（H）：" + dec_dgb.ToString());

                this.PushValue(ref bt_arr, 4, 4, false, dec_dgb);

                string s_temp = "";
                for (int i = 0; i < bt_arr.Length; i++)
                {
                    s_temp = s_temp + bt_arr[i].ToString("X") + " ";
                }

                CLogWriter.Instance.WriteLog("入口数据发送(" + s_temp + ")");

                this.mInPort.Write(bt_arr, 0, bt_arr.Length);
            }
        }

        private List<RandPairs> ReadRandPairs()
        {
            string fn = "randoms.txt";
            string[] lines = File.ReadAllLines(fn);
            List<RandPairs> lst = new List<RandPairs>();
            foreach (string line in lines)
            {
                string[] words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                lst.Add(new RandPairs(Convert.ToInt32(words[0]), Convert.ToInt32(words[1])));
            }
            return lst;
        }

        /// <summary>
        /// 从函数名来看：把bt_arr经过一定转换，变成测试数据，并发送到串口
        /// </summary>
        /// <param name="bt_arr"></param>
        public void PutTestValue(byte[] bt_arr)
        {
            //从bt_arr里截取各个有用的信息（具体什么用要看硬件的协议）
            int n_dgqd = (int)(this.ParseValue(bt_arr, 12, 4));

            CLogWriter.Instance.WriteLog("光强（100CD）：" + n_dgqd.ToString());

            decimal dec_zyp = -this.ParseValue(bt_arr, 2, 5);
            CLogWriter.Instance.WriteLog("左右偏(CM/10M)：" + dec_zyp.ToString());
            decimal dec_sxp = -this.ParseValue(bt_arr, 7, 5);
            CLogWriter.Instance.WriteLog("上下偏 （CM/10M）：" + dec_sxp.ToString());
            decimal dec_jzyp = -this.ParseValue(bt_arr, 19, 5);
            CLogWriter.Instance.WriteLog("近光左右偏（CM/10M）：" + dec_jzyp.ToString());
            decimal dec_jsxp = -this.ParseValue(bt_arr, 24, 5);
            CLogWriter.Instance.WriteLog("近光上下偏（CM/10M）：" + dec_jsxp.ToString());
            decimal dec_jdgb = this.ParseValue(bt_arr, 29, 4);
            CLogWriter.Instance.WriteLog("近光灯高比(H):" + dec_jdgb.ToString());
            //}
            //灯高
            //this.mTestResults.PutValue(s_keydg, this.ParseValue(bt_arr, 16, 3)*10);
            decimal dec_jgdg = this.ParseValue(bt_arr, 16, 3);
            CLogWriter.Instance.WriteLog("近光灯高（CM）:" + dec_jgdg.ToString());
            //硬件业务逻辑，处理某些越界极致

            Random r = new Random();

            if ((n_dgqd >= 80) && (n_dgqd < 160)) //满足这个条件，增加随机取数程序，取数的范围在160至230随机取，取值后赋给 n_dgqd ---------------------------1
            {
                n_dgqd = (int)this.lstRandPairs[0].GetRandom(r);
            }


            if (dec_jgdg <= 0)
            {
                dec_jgdg = 60;
            }
            //下面都是有关硬件参数的具体算法
            //Math.Round是四舍五入
            decimal dec_zdgb = System.Math.Round((dec_jgdg + dec_sxp) / dec_jgdg, 2);

            bool b_change = false;
            decimal d86 = this.lstRandPairs[1].GetRandom(r);
            decimal d93 = this.lstRandPairs[2].GetRandom(r);
            decimal d781 = this.lstRandPairs[3].GetRandom(r);
            decimal d782 = this.lstRandPairs[4].GetRandom(r);

            if (dec_zdgb < 0.85m)  //增加随机取数程序，将0.86改成随机取数的值，取值范围0.85至0.95 --------------2
            {
                b_change = true;
                dec_sxp = System.Math.Round(-((decimal)1 - d86) * (decimal)dec_jgdg, 1);

            }
            else if (dec_zdgb > 0.95m)  //增加随机取数程序，将0.93改成随机取数的值，取值范围0.85至0.95  -------------3
            {
                b_change = true;
                dec_sxp = System.Math.Round(-((decimal)1 - d93) * (decimal)dec_jgdg, 1);
            }

            if (dec_jdgb < (decimal)0.7)  //增加随机取数程序，将0.78改成随机取数的值，取值范围0.70至0.80 --------------4
            {
                b_change = true;
                dec_jsxp = System.Math.Round(-((decimal)1 - d781) * (decimal)dec_jgdg, 1);
            }
            else if (dec_jdgb > (decimal)0.9)   //增加随机取数程序，将0.78改成随机取数的值，取值范围0.70至0.80 --------------5
            {
                b_change = true;
                dec_jsxp = System.Math.Round(-((decimal)1 - d782) * (decimal)dec_jgdg, 1);
            }
            //最后一次使用的远光上下偏
            if (b_change)
            {
                this.mLastYGSXP = dec_sxp;
            }
            else
            {
                this.mLastYGSXP = 0;
            }

            if (b_change == false)
            {
                //没有描红
                this.mInPort.Write(bt_arr, 0, bt_arr.Length);
            }
            else
            {
                //有描红
                dec_jdgb = System.Math.Round((dec_jgdg + dec_jsxp) / dec_jgdg, 2);
                CLogWriter.Instance.WriteLog("描红后上下偏（CM/10M）：" + dec_sxp.ToString());

                this.PushValue(ref bt_arr, 7, 5, true, dec_sxp);

                CLogWriter.Instance.WriteLog("描红后光强(100CD)：" + n_dgqd.ToString());

                this.PushValue(ref bt_arr, 12, 4, false, (decimal)n_dgqd);

                CLogWriter.Instance.WriteLog("描红后近光上下偏（CM/10M）：" + dec_jsxp.ToString());
                this.PushValue(ref bt_arr, 24, 5, true, dec_jsxp);

                CLogWriter.Instance.WriteLog("描述后近光上下偏（CM/10M)：" + dec_jdgb.ToString());
                this.PushValue(ref bt_arr, 29, 4, false, dec_jdgb);

                CLogWriter.Instance.WriteLog("描红后的近光灯光（CM）：" + dec_jgdg.ToString());
                this.PushValue(ref bt_arr, 16, 3, false, dec_jgdg);

                string s_temp = "";
                for (int i = 0; i < bt_arr.Length; i++)
                {
                    s_temp = s_temp + bt_arr[i].ToString("X") + " ";
                }

                CLogWriter.Instance.WriteLog("入口数据发送(" + s_temp + ")");

                //写入数据
                //发送数据到串口
                this.mInPort.Write(bt_arr, 0, bt_arr.Length);

            }
        }


        /// <summary>
        /// 从方法名看：推送数据（不符合命名规范）
        /// </summary>
        /// <param name="bt_arr">字节序列</param>
        /// <param name="n_start">开始位</param>
        /// <param name="n_len">长度</param>
        /// <param name="b_hashh"></param>
        /// <param name="dec_value">小数值</param>
        private void PushValue(ref byte[] bt_arr, int n_start, int n_len, bool b_hashh, decimal dec_value)
        {
            string s_value = "";

            if (b_hashh)
            {
                if (dec_value >= 0)
                {
                    s_value += "0";
                }
                else
                {
                    s_value += "-";
                }
                n_len--;
            }
            //绝对值
            dec_value = System.Math.Abs(dec_value);
            //字符串
            string s_tmp = dec_value.ToString();


            if (s_tmp.Length < n_len)
            {
                int n_oldlen = s_tmp.Length;

                for (int i = 0; i < n_len - n_oldlen; i++)
                {
                    s_tmp = "0" + s_tmp;
                }
            }
            //似乎在原数据基础上加上某些'0'或'-'，成为新字符串
            s_value += s_tmp;
            //再把整个字符串转换为字节数组
            byte[] bt_temp = System.Text.Encoding.Default.GetBytes(s_value);
            //再把某个范围的字节数组复制到bt_arr（调用的函数获取这个值）
            Array.Copy(bt_temp, 0, bt_arr, n_start, n_len);
        }

        /// <summary>
        /// 从函数名看：转换值（名称不符合代码规范，不明白究竟要转换什么）
        /// </summary>
        /// <param name="bt_arr">字节序列</param>
        /// <param name="n_start">从第几位开始</param>
        /// <param name="n_len">长度</param>
        /// <returns></returns>
        private decimal ParseValue(byte[] bt_arr, int n_start, int n_len)
        {
            string s_tmp = "";
            //把这段字节序列转换为相应的字母（比如65转换为'A'）
            //https://msdn.microsoft.com/zh-cn/library/3hkfdkcx.aspx
            for (int i = n_start; i < (n_len + n_start); i++)
            {
                s_tmp += System.Convert.ToChar(bt_arr[i]).ToString();
            }

            try
            {
                //又把字母拼接起来的字符串转换为小数
                decimal dec_tmp = System.Convert.ToDecimal(s_tmp);
                //小数的字符串
                string s_tmp1 = dec_tmp.ToString();
                int n_count = 0;
                //遍历每个位的数字，直到遇到'9'结束循环
                //这段代码写得很差，可以有更优化的写法
                while (s_tmp1 != "")
                {
                    string s_nine = s_tmp1.Substring(0, 1);
                    s_tmp1 = s_tmp1.Substring(1);
                    if (s_nine == "9")
                    {
                        n_count++;
                    }
                }
                //如果'9'出现在第三位以后，直接返回0
                if (n_count >= 3)
                {
                    dec_tmp = 0;
                }
                //否则返回dec_tmp
                return dec_tmp;
            }
            catch (Exception ex)
            {
                ex = null;
                return 0;
            }
        }

        /// <summary>
        /// 当发送端口收到数据时自动触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mOutPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //把收到的数据放到数组bt_temp
                int n_len = this.mOutPort.BytesToRead;

                byte[] bt_temp = new byte[n_len];

                this.mOutPort.Read(bt_temp, 0, n_len);

                //转换为字符串保存到日志文件
                string s_temp = "";
                for (int i = 0; i < bt_temp.Length; i++)
                {
                    s_temp = s_temp + bt_temp[i].ToString("X") + " ";
                }

                CLogWriter.Instance.WriteLog("出口数据收到(" + s_temp + ")");


                if (this.mIfWork == false)
                {
                    //发送给接收端口
                    //不描红
                    this.mInPort.Write(bt_temp, 0, n_len);

                    return;
                }
                else
                {
                    //描红

                    int n_index = 0;
                    this.ProcessDataReceive(ref bt_temp, ref n_index);
                }
            }
            catch (Exception ex)
            {
                CLogWriter.Instance.WriteLog("出口转发失败。");
                CLogWriter.Instance.WriteLog(ex);
            }
        }

        void mInPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //接收到的字节数量
                int n_len = this.mInPort.BytesToRead;

                byte[] bt_temp = new byte[n_len];
                //把收到的字节存入bt_temp数组
                this.mInPort.Read(bt_temp, 0, n_len);

                //把字节格式化为十六进制字符串保存在s_temp里面
                string s_temp = "";
                for (int i = 0; i < bt_temp.Length; i++)
                {
                    s_temp = s_temp + bt_temp[i].ToString("X") + " ";
                }
                //输出s_temp到日志文件
                CLogWriter.Instance.WriteLog("入口数据收到(" + s_temp + ")");
                //把收到的字节发送到另一端口
                this.mOutPort.Write(bt_temp, 0, n_len);
            }
            catch (Exception ex)
            {
                CLogWriter.Instance.WriteLog("入口转发失败。");
                CLogWriter.Instance.WriteLog(ex);
            }
        }

        //服务停止
        protected override void OnStop()
        {
            //下面代码写法有问题，可能有更好的写法
            //主要是为了保证正常退出
            this.mExitEvent.Set();

            if (this.mExitOkEvent.WaitOne(10000, false) == false)
            {
                if (this.mThreadHandle != null)
                {
                    if (this.mThreadHandle.ThreadState != System.Threading.ThreadState.Stopped)
                    {
                        this.mThreadHandle.Abort();
                    }
                }
            }

            CLogWriter.Instance.WriteLog("服务已退出。");
        }

        #region MainThreadEntry
        /// <summary>
        /// 主线程的入口
        /// 这里面代码主要是为了确保人为关闭服务的时候，
        /// 正确关闭串口
        /// </summary>
        private void MainThreadEntry()
        {
            this.mExitEvent.Reset();
            this.mExitOkEvent.Reset();

            while (this.mExitEvent.WaitOne(1, false) == false)
            {
                System.Threading.Thread.Sleep(10);
            }

            //lock (this.mInPort)
            //{
            try
            {
                this.mInPort.Close();

                //}
                //lock (this.mOutPort)
                //{
                this.mOutPort.Close();
            }
            catch (Exception ex)
            {
                CLogWriter.Instance.WriteLog("关闭串口失败。");
                CLogWriter.Instance.WriteLog(ex);
            }
            //}
            this.mExitOkEvent.Set();

        }
        #endregion

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <returns></returns>
        private bool LoadConfig()
        {
            try
            {
                string s_tmp = "";
                //https://msdn.microsoft.com/zh-cn/library/system.configuration.configurationmanager(v=vs.110).aspx
                s_tmp = ConfigurationManager.AppSettings.Get("INPORT").Trim();
                CLogWriter.Instance.WriteLog("读取INPROT:" + s_tmp);
                this.mInPortNumber = int.Parse(s_tmp);

                s_tmp = ConfigurationManager.AppSettings.Get("OUTPORT").Trim();
                CLogWriter.Instance.WriteLog("读取OUTPORT:" + s_tmp);
                this.mOutPortNumber = int.Parse(s_tmp);

                s_tmp = ConfigurationManager.AppSettings.Get("SPEED").Trim();
                CLogWriter.Instance.WriteLog("读取SPEED:" + s_tmp);
                this.mPortSpeed = int.Parse(s_tmp);

                s_tmp = ConfigurationManager.AppSettings.Get("IFWORK").Trim();
                CLogWriter.Instance.WriteLog("读取IFWORK:" + s_tmp);
                if (s_tmp == "1")
                {
                    this.mIfWork = true;
                }
                else
                {
                    this.mIfWork = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                CLogWriter.Instance.WriteLog("读取配置文件失败。");
                CLogWriter.Instance.WriteLog(ex);
            }

            return false;
        }


    }
}
