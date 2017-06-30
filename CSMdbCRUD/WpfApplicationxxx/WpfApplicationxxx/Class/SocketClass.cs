#region
/*
 * *******************************************************************
 * 
 * 版权：EBARA
 * 
 * *******************************************************************
 * 
 * 创建人：黄凯
 * 创建时间：2015.06.24
 * 
 * *******************************************************************
 * 
 * 功能描述：Socket套接字
 * 
 * *******************************************************************
 * 
 * 
 * 
 * *******************************************************************
 */
#endregion

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DataExchang
{
    class SocketClass
    {
        /// <summary>
        /// 套接字
        /// </summary>
        private Socket fSocket;

        /// <summary>
        /// 网络数据流
        /// </summary>
        private NetworkStream fNetworkStream;

        /// <summary>
        /// socket连接超时TimeOut
        /// </summary>
        private static ushort fTimeout = 1000; 

        /// <summary>
        /// 构造函数
        /// </summary>
        public SocketClass()
        { 
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SocketClass()
        { 
        }

        /// <summary>
        /// 创建TCP连接，用NetworkStream读写
        /// </summary>
        /// <param name="aHost">IP地址</param>
        /// <param name="aPort">端口号</param>
        /// <returns>创建套接字是否成功</returns>
        public bool CreateNetworkStreamTCPConnect(string aHost, int aPort)
        {
            //创建套接字
            fSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                //Socket连接
                //fSocket.Connect(aHost, aPort);
                fSocket.Connect(new IPEndPoint(IPAddress.Parse(aHost), aPort));
                fSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, fTimeout);
                fSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, fTimeout);
                fSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, 1);

            }
            catch
            {
                //连接失败
                return false;
            }

            //等一秒
            Thread.Sleep(1000);

            //创建流连接
            fNetworkStream = new NetworkStream(fSocket,true);

            //连接成功
            return true;
        }

        /// <summary>
        /// 套接字关闭
        /// </summary>
        public void Close()
        {
            fNetworkStream.Close();
        }

        /// <summary>
        /// 判断是否连接
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            //是否创建套接字
            if (fSocket == null) return false;

            //套接字是否连接
            return fSocket.Connected;
        }

        /// <summary>
        /// 从 NetworkStream 读取数据。
        /// </summary>
        /// <param name="aByte">类型 Byte 的数组，它是内存中用于存储从 NetworkStream 读取的数据的位置。</param>
        /// <param name="aOffset">buffer 中开始将数据存储到的位置。</param>
        /// <param name="aLength">要从 NetworkStream 中读取的字节数</param>
        /// <returns></returns>
        public int ReadNetworkStream(byte[] aByte, int aOffset, int aLength)
        {
            if (IsConnected())
            {
                try
                {
                    return fNetworkStream.Read(aByte, aOffset, aLength);
                }
                catch
                {
                    return 0;
                }
                
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// 将数据写入 NetworkStream。
        /// </summary>
        /// <param name="aByte">类型 Byte 的数组，该数组包含要写入 NetworkStream 的数据。</param>
        /// <param name="aOffset">buffer 中开始写入数据的位置。</param>
        /// <param name="aLength">要写入 NetworkStream 的字节数。</param>
        public bool WriteNetworkStream(byte[] aByte, int aOffset, int aLength)
        {
            if (IsConnected())
            {
                try
                {
                    fNetworkStream.Write(aByte, aOffset, aLength);
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
            else
            {
                return true; 
            }
        }

        /// <summary>
        /// 刷新流中的数据。 保留此方法供将来使用。
        /// </summary>
        public void Flush()
        {
            if (IsConnected())
            {
                fNetworkStream.Flush();
            }
            else
            {
                return;
            }
        }
    }
}
