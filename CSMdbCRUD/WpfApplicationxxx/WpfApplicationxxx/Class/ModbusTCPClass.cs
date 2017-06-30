using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataExchang.Class
{
    class ModbusTCPClass : ModbusClass
    {
        /// <summary>
        /// modbus/TCP 对象
        /// </summary>
        public ModBusTCPFrameClass ModBusTCPFrameObject = null;

        /// <summary>
        /// 读取Timeout
        /// </summary>
        private int fReadTimeout;

        /// <summary>
        /// 主站IP地址
        /// </summary>

        //   public string Host = "192.168.191.3";
       // public string Host = "127.0.0.1";//指任意IP！！！
              public string Host = "192.168.0.2";

        /// <summary>
        /// 主站端口号
        /// </summary>
        public int Post = 3000;
         
        /// <summary>
        /// 读寄存器套接字对象
        /// </summary>
        public SocketClass SocketRegObject = null;

        /// <summary>
        /// 读线圈套接字对象
        /// </summary>
        public SocketClass SocketCoilObject = null;

        /// <summary>
        /// 构造函数 
        /// </summary>
        public ModbusTCPClass()
        {
            //变量初始化
            ModBusTCPFrameObject = new ModBusTCPFrameClass();
            SocketRegObject = new SocketClass();
            SocketCoilObject = new SocketClass();
            fReadTimeout = 1000;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ModbusTCPClass()
        {
        }

        /// <summary>
        /// 连接寄存器
        /// </summary> 
        /// <param name="aHost">主机地址</param>
        /// <param name="aPost">端口</param>
        /// <returns>连接是否成功</returns>
        public bool ConnectReg(string aHost, int aPost)
        {
            //连接主站
            Host = aHost;
            Post = aPost;
            return SocketRegObject.CreateNetworkStreamTCPConnect(aHost, aPost);
        }

        /// <summary>
        /// 连接线圈
        /// </summary>
        /// <param name="aHost">主机地址</param>
        /// <param name="aPost">端口</param>
        /// <returns>连接是否成功</returns>
        public bool ConnectCoil(string aHost, int aPost)
        {
            //连接主站
            Host = aHost;
            Post = aPost;
            return SocketCoilObject.CreateNetworkStreamTCPConnect(aHost, aPost);
        }

        /// <summary>
        /// 再次连接
        /// </summary>
        /// <returns></returns>
        public override bool Connect()
        {
            
            //连接主站
           return (SocketRegObject.CreateNetworkStreamTCPConnect(Host, Post));
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public override void DisConnect()
        {
            SocketCoilObject.Close();
            SocketRegObject.Close();
        }

        /// <summary>
        /// 读取寄存器
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">开始地址</param>
        /// <param name="aLenth">读取长度（字）</param>
        /// <param name="aBuffer">缓存</param>
        /// <returns>字节数</returns>
        public int ReadHoldingRegisters
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth, byte[] aBuffer)
        {
            //NetworkStream读取位置
            int iIndex = 0;

            //读取字节长度
            int iRet = 0;

            //time out
            int iTimeOut = fReadTimeout;

            //获得读指令帧
            byte[] bFrame;
            bFrame = ModBusTCPFrameObject.GetReadHoldingRegistersFrame(aSlaveAddr, aAddr, aLenth);//40);

            //发送指令帧
            SocketRegObject.WriteNetworkStream(bFrame, 0, bFrame.Length);
            SocketRegObject.Flush();
             
            //延迟
            Thread.Sleep(100);
            iTimeOut -= 100;

            //获得内容缓存
            byte[] bResultBuf = new byte[aLenth * 2 + 9];

            //读指令帧
            iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

            //未读取到数据
             if (iRet == 0) return 0;

            //读取位置偏移
            iIndex += iRet;

            //未读出状态字节
            while (iIndex < 9)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回错误码
            if (bResultBuf[8] == 0x80 + 0x03)//bResultBuf[8]是读出的数据
            {
                return 0;
            }

            //未全部结束
            while (iIndex < bResultBuf.Length)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回结果
            Array.Copy(bResultBuf, 9, aBuffer, 0, aLenth * 2);

            //返回读取的字节数
            return aLenth * 2;
        }

        /// <summary>
        /// 写寄存器
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">开始地址</param>
        /// <param name="aLenth">要写长度（字节）</param>
        /// <param name="aBuffer">要写的内容</param>
        /// <returns>写字节数</returns>
        public int WriteMultipleRegisters
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth, byte[] aBuffer)
        {
            //NetworkStream读取位置
            int iIndex = 0;

            //读取字节长度
            int iRet = 0;

            //time out
            int iTimeOut = fReadTimeout;

            //获得写指令帧
            byte[] bFrame;
            bFrame = ModBusTCPFrameObject.GetWriteMultipleRegistersFrame(aSlaveAddr, aAddr, aLenth, aBuffer);

            //发送指令帧
            SocketRegObject.WriteNetworkStream(bFrame, 0, bFrame.Length);
            SocketRegObject.Flush();

            //延迟 
            Thread.Sleep(100);
            iTimeOut -= 100;

            //获得返回指令帧
            byte[] bResultBuf = new byte[12];

            //读指令帧
            iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

            //未读取到数据
             if (iRet == 0) return 0;

            //读取位置偏移
            iIndex += iRet;

            //未读出状态字节
            while (iIndex < 9)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回错误码
            if (bResultBuf[8] == 0x80 + 0x10)
            {
                return 0;
            }

            //未全部结束
            while (iIndex < bResultBuf.Length)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回写字节数
            return aLenth * 2;
        }

        /// <summary>
        /// 写单个寄存器
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">地址</param>
        /// <param name="aDataBuffer">内容</param>
        /// <returns>写字节数</returns>
        public int WriteSingleRegister
            (byte aSlaveAddr, UInt16 aAddr, byte[] aDataBuffer)
        {
            //NetworkStream读取位置
            int iIndex = 0;

            //读取字节长度
            int iRet = 0;

            //time out
            int iTimeOut = fReadTimeout;

            //获得写指令帧
            byte[] bFrame;
            bFrame = ModBusTCPFrameObject.GetWriteSingleRegisterFrame(aSlaveAddr, aAddr, aDataBuffer);

            //发送指令帧
            SocketRegObject.WriteNetworkStream(bFrame, 0, bFrame.Length);
            SocketRegObject.Flush();

            //延迟
            Thread.Sleep(100);
            iTimeOut -= 100;

            //获得返回指令帧
            byte[] bResultBuf = new byte[12];

            //读指令帧
            iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

            //未读取到数据
            if (iRet == 0) return 0;

            //读取位置偏移
            iIndex += iRet;

            //未读出状态字节
            while (iIndex < 9)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回错误码
            if (bResultBuf[8] == 0x80 + 0x10)
            {
                return 0;
            }

            //未全部结束
            while (iIndex < bResultBuf.Length)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketRegObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回写字节数
            return  2;
        }

        /// <summary>
        /// 读线圈
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">开始地址</param>
        /// <param name="aLenth">要读长度（位）</param>
        /// <param name="aBuffer">要读内容的缓存</param>
        /// <returns>字节数读取</returns>
        public int ReadCoils
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth, byte[] aBuffer)
        {
            //NetworkStream读取位置
            int iIndex = 0;

            //读取字节长度
            int iRet = 0;

            //time out
            int iTimeOut = fReadTimeout;

            //获得读指令帧
            byte[] bFrame;
            bFrame = ModBusTCPFrameObject.GetReadCoilsFrame(aSlaveAddr, aAddr, aLenth);

            //发送指令帧
            SocketCoilObject.WriteNetworkStream(bFrame, 0, bFrame.Length);
            SocketCoilObject.Flush();

            //延迟
            Thread.Sleep(100);
            iTimeOut -= 100;

            //获得缓存长度
            UInt16 uiLenth = 0;
            if (aLenth % 8 > 0)
            {
                uiLenth = Convert.ToUInt16(aLenth / 8 + 1);
            }
            else
            {
                uiLenth = Convert.ToUInt16(aLenth / 8);
            }

            //获得内容缓存
            byte[] bResultBuf = new byte[uiLenth + 9];

            //读指令帧
            iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

            //未读取到数据
            if (iRet == 0) return 0;

            //读取位置偏移
            iIndex += iRet;

            //未读出状态字节
            while (iIndex < 9)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回错误码
            if (bResultBuf[8] == 0x80 + 0x01)
            {
                return 0;
            }

            //未全部结束
            while (iIndex < bResultBuf.Length)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回结果
            Array.Copy(bResultBuf, 9, aBuffer, 0, uiLenth);

            //返回读取的字节数
            return aLenth;
        }

        /// <summary>
        /// 写单个线圈
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">地址</param>
        /// <param name="aDataBuffer">值</param>
        /// <returns>写字节数</returns>
        public int WriteSingleCoil
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aDataBuffer)
        {
            //NetworkStream读取位置
            int iIndex = 0;

            //读取字节长度
            int iRet = 0;

            //time out
            int iTimeOut = fReadTimeout;

            //获得写指令帧
            byte[] bFrame;
            bFrame = ModBusTCPFrameObject.GetWriteSingleCoilFrame(aSlaveAddr, aAddr, aDataBuffer);

            //发送指令帧
            SocketCoilObject.WriteNetworkStream(bFrame, 0, bFrame.Length);
            SocketCoilObject.Flush();

            //延迟
            Thread.Sleep(100);
            iTimeOut -= 100;

            //获得返回指令帧
            byte[] bResultBuf = new byte[12];

            //读指令帧
            iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

            //未读取到数据
            if (iRet == 0) return 0;

            //读取位置偏移
            iIndex += iRet;

            //未读出状态字节
            while (iIndex < 9)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回错误码
            if (bResultBuf[8] == 0x80 + 0x05)
            {
                return 0;
            }

            //未全部结束
            while (iIndex < bResultBuf.Length)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回写字节数
            return 1;
        }


        /// <summary>
        /// 写多个线圈
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">开始地址</param>
        /// <param name="aLenth">要写长度（位）</param>
        /// <param name="aDataBuffer">要写内容的缓存</param>
        /// <returns>写字节数</returns>
        public int WriteMultipleCoils
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth, byte[] aDataBuffer)
        {
            //NetworkStream读取位置
            int iIndex = 0;

            //读取字节长度
            int iRet = 0;

            //time out
            int iTimeOut = fReadTimeout;

            //获得写指令帧
            byte[] bFrame;
            bFrame = ModBusTCPFrameObject.GetMultipleCoilsFrame(aSlaveAddr, aAddr, aLenth, aDataBuffer);

            //发送指令帧
            SocketCoilObject.WriteNetworkStream(bFrame, 0, bFrame.Length);
            SocketCoilObject.Flush();

            //延迟
            Thread.Sleep(100);
            iTimeOut -= 100;

            //获得返回指令帧
            byte[] bResultBuf = new byte[12];

            //读指令帧
            iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

            //未读取到数据
            if (iRet == 0) return 0;

            //读取位置偏移
            iIndex += iRet;

            //未读出状态字节
            while (iIndex < 9)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回错误码
            if (bResultBuf[8] == 0x80 + 0x0F)
            {
                return 0;
            }

            //未全部结束
            while (iIndex < bResultBuf.Length)
            {
                //延迟
                Thread.Sleep(100);
                iTimeOut -= 100;

                //time out 时间到
                if (iTimeOut < 0) return 0;

                //读指令帧
                iRet = SocketCoilObject.ReadNetworkStream(bResultBuf, iIndex, bResultBuf.Length - iIndex);

                //未读取到数据
                if (iRet == 0) return 0;

                //读取位置偏移
                iIndex += iRet;
            }

            //返回写字节数
            return bFrame[12];
        }

    }
}
