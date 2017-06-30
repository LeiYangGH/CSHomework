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
 * 功能描述：ModbusTCP协议类
 * 
 * *******************************************************************
 * 
 * 
 * 
 * *******************************************************************
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExchang
{
    class ModBusTCPFrameClass
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public ModBusTCPFrameClass()
        { 
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ModBusTCPFrameClass()
        {
 
        }
        
        /// <summary>
        /// F01读线圈
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">线圈地址</param>
        /// <param name="aLenth">读取长度（位）</param>
        /// <returns>返回指令帧</returns>
        public byte[] GetReadCoilsFrame
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth)
        {
            //读功能命令
            byte byteFunction = 0x01;

            //打包命令帧
            byte[] byteCommand = new byte[12];

            //Header
            byteCommand[0] = 0;
            byteCommand[1] = 0;
            byteCommand[2] = 0;
            byteCommand[3] = 0;
            byteCommand[4] = 0;

            //帧内容长度
            byteCommand[5] = (byte)((byteCommand.Length - 6) % 256);

            //Slave Address
            byteCommand[6] = aSlaveAddr;

            //Function
            byteCommand[7] = byteFunction;

            //Starting Address HI
            byteCommand[8] = (byte)(aAddr / 256);

            //Starting Address LO
            byteCommand[9] = (byte)(aAddr % 256);

            //No of Coils Hi
            byteCommand[10] = (byte)(aLenth / 256);

            //No of Coils Lo
            byteCommand[11] = (byte)(aLenth % 256);

            //返回命令帧
            return byteCommand.ToArray();
        }

        /// <summary>
        /// F05写单个线圈
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">线圈地址</param>
        /// <param name="aDataBuffer">ON/OFF</param>
        /// <returns>返回指令帧</returns>
        public byte[] GetWriteSingleCoilFrame
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aDataBuffer)
        {

            //写功能命令
            byte byteFunction = 0x05;

            //打包命令帧
            byte[] byteCommand = new byte[12];

            //Header
            byteCommand[0] = 0;
            byteCommand[1] = 0;
            byteCommand[2] = 0;
            byteCommand[3] = 0;
            byteCommand[4] = 0;

            //帧内容长度
            byteCommand[5] = (byte)((byteCommand.Length - 6) % 256);

            //Slave Address
            byteCommand[6] = aSlaveAddr;

            //Function
            byteCommand[7] = byteFunction;

            //Coil Address HI
            byteCommand[8] = (byte)(aAddr / 256);

            //Coil Address LO
            byteCommand[9] = (byte)(aAddr % 256);

            if (aDataBuffer > 0)
            {
                //Write Data Hi
                byteCommand[10] = Convert.ToByte(255);

                //Write Data Lo
                byteCommand[11] = Convert.ToByte(0);
            }
            else
            {
                //Write Data Hi
                byteCommand[10] = Convert.ToByte(0);

                //Write Data Lo
                byteCommand[11] = Convert.ToByte(0);
            }

            //返回打包成功
            return byteCommand.ToArray();
        }

        /// <summary>
        /// F03读寄存器
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">寄存器地址</param>
        /// <param name="aLenth">长度</param>
        /// <returns>返回指令帧</returns>
        public byte[] GetReadHoldingRegistersFrame
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth)
        {
            //读功能命令
            byte byteFunction = 0x03;

            //打包命令帧
            byte[] byteCommand = new byte[12];

            //Header
            byteCommand[0] = 0;
            byteCommand[1] = 0;
            byteCommand[2] = 0;
            byteCommand[3] = 0;
            byteCommand[4] = 0;

            //帧内容长度
            byteCommand[5] = (byte)((byteCommand.Length - 6) % 256);

            //Slave Address
            byteCommand[6] = aSlaveAddr;

            //Function
            byteCommand[7] = byteFunction;

            //Starting Address HI
            byteCommand[8] = (byte)(aAddr / 256);

            //Starting Address LO
            byteCommand[9] = (byte)(aAddr % 256);

            //Number of Registers Hi
            byteCommand[10] = (byte)(aLenth / 256);

            //Number of Registers Lo
            byteCommand[11] = (byte)(aLenth % 256);

            //返回命令帧
            return byteCommand.ToArray();
        }

        /// <summary>
        /// F10写多个寄存器
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">寄存器地址</param>
        /// <param name="aLenth">长度</param>
        /// <param name="aDataBuffer">写数据</param>
        /// <returns>返回指令帧</returns>
        public byte[] GetWriteMultipleRegistersFrame
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth, byte[] aDataBuffer)
        {
            //写功能命令
            byte byteFunction = 0x10;

            //打包命令帧
            byte[] byteCommand = new byte[aLenth * 2 + 13];

            //Header
            byteCommand[0] = 0;
            byteCommand[1] = 0;
            byteCommand[2] = 0;
            byteCommand[3] = 0;
            byteCommand[4] = 0;

            //帧内容长度
            byteCommand[5] = (byte)((byteCommand.Length - 6) % 256);

            //Slave Address
            byteCommand[6] = aSlaveAddr;

            //Function
            byteCommand[7] = byteFunction;

            //Starting Address HI
            byteCommand[8] = (byte)(aAddr / 256);

            //Starting Address LO
            byteCommand[9] = (byte)(aAddr % 256);

            //Number of Registers Hi
            byteCommand[10] = (byte)(aLenth / 256);

            //Number of Registers Lo
            byteCommand[11] = (byte)(aLenth % 256);

            //Byte Count（一个寄存器两个字节）
            byteCommand[12] = (byte)((aLenth * 2) % 256);

            //打包
            if (aDataBuffer.Length < byteCommand[12]) return null;
            Array.Copy(aDataBuffer, 0, byteCommand, 13, byteCommand[12]);

            //返回打包成功
            return byteCommand.ToArray();
        }

        /// <summary>
        /// F06写单个寄存器
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">寄存器地址</param>
        /// <param name="aDataBuffer">写数据</param>
        /// <returns>返回指令帧</returns>
        public byte[] GetWriteSingleRegisterFrame
            (byte aSlaveAddr, UInt16 aAddr, byte[] aDataBuffer)
        {
            //写功能命令
            byte byteFunction = 0x06;

            //打包命令帧
            byte[] byteCommand = new byte[12];

            //Header
            byteCommand[0] = 0;
            byteCommand[1] = 0;
            byteCommand[2] = 0;
            byteCommand[3] = 0;
            byteCommand[4] = 0;

            //帧内容长度
            byteCommand[5] = (byte)((byteCommand.Length - 6) % 256);

            //Slave Address
            byteCommand[6] = aSlaveAddr;

            //Function
            byteCommand[7] = byteFunction;

            //Starting Address HI
            byteCommand[8] = (byte)(aAddr / 256);

            //Starting Address LO
            byteCommand[9] = (byte)(aAddr % 256);

            //Write Data
            Array.Copy(aDataBuffer, 0, byteCommand, 10, 2);

            //返回打包成功
            return byteCommand.ToArray();
        }

        /// <summary>
        /// F0F写多个线圈
        /// </summary>
        /// <param name="aSlaveAddr">从轮询地址</param>
        /// <param name="aAddr">寄存器地址</param>
        /// <param name="aLenth">写长度（位）</param>
        /// <param name="aDataBuffer">写数据</param>
        /// <returns>返回指令帧</returns>
        public byte[] GetMultipleCoilsFrame
            (byte aSlaveAddr, UInt16 aAddr, UInt16 aLenth, byte[] aDataBuffer)
        {
            //写功能命令
            byte byteFunction = 0x0F;

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

            //打包命令帧
            byte[] byteCommand = new byte[uiLenth + 13];

            //Header
            byteCommand[0] = 0;
            byteCommand[1] = 0;
            byteCommand[2] = 0;
            byteCommand[3] = 0;
            byteCommand[4] = 0;

            //帧内容长度
            byteCommand[5] = (byte)((byteCommand.Length - 6) % 256);

            //Slave Address
            byteCommand[6] = aSlaveAddr;

            //Function
            byteCommand[7] = byteFunction;

            //Starting Address HI
            byteCommand[8] = (byte)(aAddr / 256);

            //Starting Address LO
            byteCommand[9] = (byte)(aAddr % 256);

            //Number of Registers Hi
            byteCommand[10] = (byte)(aLenth / 256);

            //Number of Registers Lo
            byteCommand[11] = (byte)(aLenth % 256);

            //Byte Count（一个寄存器两个字节）
            byteCommand[12] = (byte)(uiLenth % 256);

            //打包
            if (aDataBuffer.Length < byteCommand[12]) return null;
            Array.Copy(aDataBuffer, 0, byteCommand, 13, byteCommand[12]);

            //返回打包成功
            return byteCommand.ToArray();
        }
    }
}
