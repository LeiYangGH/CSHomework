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
 * 功能描述：Modbus连接读取
 * 
 * *******************************************************************
 * 
 * 
 * 
 * *******************************************************************
 */
#endregion

using DataExchang.Class;
using DataExchang.Define;
using System;
using System.Collections;
using System.Linq;

namespace DataExchang.Connect
{
    /// <summary>
    /// modbus交互类
    /// </summary>
    class ModBusConnectClass : ModbusTCPClass
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ModBusConnectClass()
        {
           
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ModBusConnectClass()
        {
        }

        /// <summary>
        /// 读取数字量
        /// </summary>
        /// <param name="aModbusItem">modbus变量表</param>
        /// <returns>读写是否成功</returns>
        public bool ReadItemsFigurePiece(ref ModbusItem[] aModbusItem)
        {
            //从轮询地址
            byte bSlaveID = 0;

            //开始地址
            UInt16 uint16StartAddr = 0;

            //读取长度
            UInt16 uint16Length = 0;

            //排序
            var varSortItem = from item in aModbusItem
                              where item.ItemType == "BOOLEAN"
                              orderby item.SlaveID, item.ItemAddress
                              select item;
            ModbusItem[] mbItems = varSortItem.ToArray();

            if (mbItems.Count() > 0)
            {

                //获得开始地址
                uint16StartAddr = Convert.ToUInt16(mbItems[0].ItemAddress);

                //获得读取长度
                uint16Length = Convert.ToUInt16(mbItems[mbItems.Length - 1].ItemAddress - uint16StartAddr + 1);

                //获取从轮寻地址
                bSlaveID = Convert.ToByte(mbItems[0].SlaveID);

                //当有读取长度时
                if (uint16Length > 0)
                {
                    UInt16 uiLenth = 0;
                    if (uint16Length % 8 > 0)
                    {
                        uiLenth = Convert.ToUInt16(uint16Length / 8 + 1);
                    }
                    else
                    {
                        uiLenth = Convert.ToUInt16(uint16Length / 8);
                    }

                    //数据缓存
                    byte[] bBuffer = new byte[uiLenth];

                    try
                    {
                        //读线圈
                        if (ReadCoils(bSlaveID, uint16StartAddr, uint16Length, bBuffer) == uint16Length)
                        {
                            for (int i = 0; i < mbItems.Length; i++)
                            {
                                //获得变量值缓存索引
                                int iItemValueBufferIndex = (mbItems[i].ItemAddress - uint16StartAddr) / 8;

                                //更新状态
                                mbItems[i].Status = ValueState.STATUS_GOOG;

                                //时间戳
                                mbItems[i].UpdateTime = DateTime.Now;

                                //值
                                byte[] bByte = BitConverter.GetBytes(bBuffer[iItemValueBufferIndex]);
                                BitArray baList = new BitArray(bByte);
                                mbItems[i].Value = Convert.ToDecimal(baList[(mbItems[i].ItemAddress - uint16StartAddr) % 8]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < mbItems.Length; i++)
                            {
                                //值
                                //mbItems[i].Value = false;

                                //更新状态
                                mbItems[i].Status = ValueState.STATUS_BAD;

                                //时间戳
                                mbItems[i].UpdateTime = DateTime.Now;
                            }
#if DEBUG
                            //Log.WriteLog("ReadItemsFigurePiece error");
#else
                            //Log.WriteLog("ReadItemsFigurePiece error");
#endif
                        }
                    }
                    catch (Exception ex)
                    {
                        for (int i = 0; i < mbItems.Length; i++)
                        {
                            //更新状态
                            mbItems[i].Status = ValueState.STATUS_BAD;

                            //时间戳
                            mbItems[i].UpdateTime = DateTime.Now;
                        }
#if DEBUG
                        //Log.WriteLog(ex.ToString());
#else
                        //Log.WriteLog(ex.ToString());
#endif
                        return false;
                    }
                }
            }
            //读取成功
            return true;
        }

        /// <summary>
        /// 读模拟量数据块
        /// </summary>
        /// <param name="aModbusItem">modbus变量表</param>
        /// <returns>读写是否成功</returns>
        public bool ReadItemsSimulationPiece(ref ModbusItem[] aModbusItem)
        {
            //从轮询地址
            byte bSlaveID = 0;

            //开始地址
            UInt16 uint16StartAddr = 0;

            //读取长度
            UInt16 uint16Length = 0;

            //排序
            var varSortItem = from item in aModbusItem
                              where item.ItemType != "BOOLEAN"
                              orderby item.SlaveID, item.ItemAddress
                              select item;
            ModbusItem[] mbItems = varSortItem.ToArray();

            //获得开始地址
            uint16StartAddr = Convert.ToUInt16(mbItems[0].ItemAddress);

            //获得读取长度
            uint16Length = Convert.ToUInt16(mbItems[mbItems.Length - 1].ItemAddress - uint16StartAddr);

            //判断最后一位需要缓存的长度
            switch (mbItems[mbItems.Length - 1].ItemType)
            {
                case "WORD":
                    uint16Length += 1;
                    break;
                case "DWORD":
                case "FLOATINVERSE":
                case "FLOAT":
                    uint16Length += 2;
                    break;
                case "STRING":
                    uint16Length += 5;
                    break;
            }

            //获取从轮寻地址
            bSlaveID = Convert.ToByte(mbItems[0].SlaveID);

            //当有读取长度时
            if (uint16Length > 0)
            {
                //数据缓存
                byte[] bBuffer = new byte[uint16Length * 2];

                try
                {
                    //读寄存器
                    if (ReadHoldingRegisters(bSlaveID, uint16StartAddr, uint16Length, bBuffer) == uint16Length * 2)
                    {

                        for (int i = 0; i < mbItems.Length; i++)
                        {
                            //获得变量值缓存索引
                            int iItemValueBufferIndex = (mbItems[i].ItemAddress - uint16StartAddr) * 2;

                            //更新状态
                            mbItems[i].Status = ValueState.STATUS_GOOG;

                            //时间戳
                            mbItems[i].UpdateTime = DateTime.Now;

                            //变量数值缓存
                            ItemValue ivValue = new ItemValue();

                            //数值解析
                            switch (mbItems[i].ItemType)
                            {
                                //word类型数据解析
                                case "WORD":
                                    ivValue.B0 = bBuffer[iItemValueBufferIndex + 1];
                                    ivValue.B1 = bBuffer[iItemValueBufferIndex];
                                    mbItems[i].Value = Convert.ToDecimal(ivValue.Word);
                                    break;

                                //dword类型解析
                                case "DWORD":
                                    ivValue.B0 = bBuffer[iItemValueBufferIndex + 1];
                                    ivValue.B1 = bBuffer[iItemValueBufferIndex];
                                    ivValue.B2 = bBuffer[iItemValueBufferIndex + 3];
                                    ivValue.B3 = bBuffer[iItemValueBufferIndex + 2];
                                    mbItems[i].Value = Convert.ToDecimal(ivValue.DWord);
                                    break;

                                //float类型解析
                                case "FLOAT":
                                    ivValue.B0 = bBuffer[iItemValueBufferIndex + 1];
                                    ivValue.B1 = bBuffer[iItemValueBufferIndex];
                                    ivValue.B2 = bBuffer[iItemValueBufferIndex + 3];
                                    ivValue.B3 = bBuffer[iItemValueBufferIndex + 2];
                                    mbItems[i].Value = Convert.ToDecimal(ivValue.Float);
                                    break;

                                //float inverse类型解析
                                case "FLOATINVERSE":
                                    ivValue.B0 = bBuffer[iItemValueBufferIndex + 3];
                                    ivValue.B1 = bBuffer[iItemValueBufferIndex + 2];
                                    ivValue.B2 = bBuffer[iItemValueBufferIndex + 1];
                                    ivValue.B3 = bBuffer[iItemValueBufferIndex];
                                    mbItems[i].Value = Convert.ToDecimal(ivValue.Float);
                                    break;

                                //字符串类型解析
                                case "STRING":
                                    char[] cStrBuf = new char[10];
                                    Array.Copy(bBuffer, iItemValueBufferIndex, cStrBuf, 0, 10);
                                    string strValue = new string(cStrBuf);
                                    mbItems[i].Value = strValue = strValue.Replace(new String(new Char[] { '\0' }), "");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < mbItems.Length; i++)
                        {
                            //更新状态
                            mbItems[i].Status = ValueState.STATUS_BAD;

                            //时间戳
                            mbItems[i].UpdateTime = DateTime.Now;
                        }
#if DEBUG
                        //Log.WriteLog("ReadItemsSimulationPiece error");
#else
                        //Log.WriteLog("ReadItemsSimulationPiece error");
#endif
                        //读失败
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    for (int i = 0; i < mbItems.Length; i++)
                    {
                        //更新状态
                        mbItems[i].Status = ValueState.STATUS_BAD;

                        //时间戳
                        mbItems[i].UpdateTime = DateTime.Now;
                    }
#if DEBUG
                    //Log.WriteLog(ex.ToString());
#else
                    //Log.WriteLog(ex.ToString());
#endif
                }
            }

            //读取成功
            return true;
        }

        /// <summary>
        /// 读变量表
        /// </summary>
        /// <param name="aModbusItem">需要更新的变量表</param>
        /// <returns>读写是否成功</returns>
        public bool  ReadItems(ref ModbusItem[] aModbusItem)
    //        public bool ReadItems(ref ModbusItem aModbusItem)//改成与WriteItem格式一样，去掉[]
        {
            //读线圈或读寄存器模式
            CoilOrRegister iCoilOrRegiterMode = CoilOrRegister.Register;

            //从轮询地址
            byte bSlaveID = 0;

            //变量长度
            int iCount = 0;

            //开始地址
            UInt16 uint16StartAddr = 0;

            //排序
            
           var varSortItem = from item in aModbusItem
                              orderby item.SlaveID, item.ItemAddress 
                              select item;
            ModbusItem[] mbItems = varSortItem.ToArray();

            //获得变量个数
            iCount = mbItems.Length;

            //读取变量
            //遍历更新所有变量
            for (int i = 0; i < iCount; i++)
            {
                //读取长度
                UInt16 uint16Length = 0;

                //获得从轮询地址
                bSlaveID = Convert.ToByte(mbItems[i].SlaveID);

                //获得开始地址
                uint16StartAddr = Convert.ToUInt16(mbItems[i].ItemAddress);

                //判断需要缓存的长度
                switch (mbItems[i].ItemType)
                {
                    case "WORD":
                        uint16Length += 1;
                        break;
                    case "DWORD":
                    case "FLOAT":
                        uint16Length += 2;
                        break;
                    case "STRING":
                        uint16Length += 5;
                        break;
                    case "BOOLEAN":
                        iCoilOrRegiterMode = CoilOrRegister.Coil;
                        uint16Length += 1;
                        break;
                }

                //当有读取长度时
                if (uint16Length > 0)
                {
                    if (iCoilOrRegiterMode == CoilOrRegister.Coil)
                    {
                        //数据缓存
                        byte[] bBuffer = new byte[uint16Length];

                        try
                        {
                            //读线圈
                            if (ReadCoils(bSlaveID, uint16StartAddr, uint16Length, bBuffer) == uint16Length)
                            {
                                //获得变量值缓存索引
                                int iItemValueBufferIndex = (mbItems[i].ItemAddress - uint16StartAddr);

                                //更新状态
                                mbItems[i].Status = ValueState.STATUS_GOOG;

                                //时间戳
                                mbItems[i].UpdateTime = DateTime.Now;

                                //值
                                mbItems[i].Value = Convert.ToBoolean(bBuffer[iItemValueBufferIndex]);
                            }
                            else
                            {
                                //更新状态
                                mbItems[i].Status = ValueState.STATUS_BAD;

                                //时间戳
                                mbItems[i].UpdateTime = DateTime.Now;
                            }
                        }
                        catch
                        {
                            //更新状态
                            mbItems[i].Status = ValueState.STATUS_BAD;

                            //时间戳
                            mbItems[i].UpdateTime = DateTime.Now;

                            //读失败
                            return false;
                        }
                    }
                    else if (iCoilOrRegiterMode == CoilOrRegister.Register)
                    {
                        //数据缓存
                        byte[] bBuffer = new byte[uint16Length * 2];

                        try
                        {
                            //读寄存器
                            if (ReadHoldingRegisters(bSlaveID, uint16StartAddr, uint16Length, bBuffer) == uint16Length * 2)
                            {
                                //获得变量值缓存索引
                                int iItemValueBufferIndex = (mbItems[i].ItemAddress - uint16StartAddr) * 2;

                                //更新状态
                                mbItems[i].Status = ValueState.STATUS_GOOG;

                                //时间戳
                                mbItems[i].UpdateTime = DateTime.Now;

                                //变量数值缓存
                                ItemValue ivValue = new ItemValue();

                                //数值解析
                                switch (mbItems[i].ItemType)
                                {
                                    //word类型数据解析
                                    case "WORD":
                                        ivValue.B0 = bBuffer[iItemValueBufferIndex + 1];
                                        ivValue.B1 = bBuffer[iItemValueBufferIndex];
                                        mbItems[i].Value = Convert.ToDecimal(ivValue.Word);
                                        break;

                                    //dword类型解析
                                    case "DWORD":
                                        ivValue.B0 = bBuffer[iItemValueBufferIndex + 1];
                                        ivValue.B1 = bBuffer[iItemValueBufferIndex];
                                        ivValue.B2 = bBuffer[iItemValueBufferIndex + 3];
                                        ivValue.B3 = bBuffer[iItemValueBufferIndex + 2];
                                        mbItems[i].Value = Convert.ToDecimal(ivValue.DWord);
                                        break;

                                    //float类型解析
                                    case "FLOAT":
                                        ivValue.B0 = bBuffer[iItemValueBufferIndex + 1];
                                        ivValue.B1 = bBuffer[iItemValueBufferIndex];
                                        ivValue.B2 = bBuffer[iItemValueBufferIndex + 3];
                                        ivValue.B3 = bBuffer[iItemValueBufferIndex + 2];
                                        mbItems[i].Value = Convert.ToDecimal(ivValue.Float);
                                        break;

                                    //字符串类型解析
                                    case "STRING":
                                        char[] cStrBuf = new char[10];
                                        Array.Copy(bBuffer, iItemValueBufferIndex, cStrBuf, 0, 10);
                                        string strValue = new string(cStrBuf);
                                        mbItems[i].Value = strValue = strValue.Replace(new String(new Char[] { '\0' }), "");
                                        break;
                                }
                            }
                            else
                            {
                                //更新状态
                                mbItems[i].Status = ValueState.STATUS_BAD;

                                //时间戳
                                mbItems[i].UpdateTime = DateTime.Now;

                                //读失败
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            //更新状态
                            mbItems[i].Status = ValueState.STATUS_BAD;

                            //时间戳
                            mbItems[i].UpdateTime = DateTime.Now;

#if DEBUG
                            //Log.WriteLog(ex.ToString());
#else
                            //Log.WriteLog(ex.ToString());
#endif
                        }
                    }
                    else
                    {
                        //更新状态
                        mbItems[i].Status = ValueState.STATUS_BAD;

                        //时间戳
                        mbItems[i].UpdateTime = DateTime.Now;
                    }
                }
            }

            //读成功
            return true;
        }

        /// <summary>
        /// 写变量
        /// </summary>
        /// <param name="aModbusItem">变量</param>
        /// <param name="aValue">值</param>
        /// <returns>是否写成功</returns>
        public bool WriteItem(ref ModbusItem aModbusItem, Iolist aValue)
        {
            //如果值相等则不需再重写
            //if (aModbusItem.Value.ToString().Trim() == "" || aValue.Values.Value.ToString().Trim() == "")
            //    return false;

            if (aModbusItem.Value.ToString() == aValue.Values.Value.ToString()
                && Convert.ToDecimal(aValue.Values.Value) != decimal.MaxValue) 
                return false;

            //if (aModbusItem.Direction == RwDirection.ReadWrite
            //                && (aValue.TagName == "FormerBreakageCount")
            //                || aValue.TagName == "RunCounting"
            //                || aValue.TagName == "StopCounting")
            //{
            //    Log.WriteLog(Host.ToString() + "MODBUS WriteJob : " + aValue.TagName
            //        + " , " + aValue.TagCode
            //        + " , " + aModbusItem.Value
            //        + " , " + aValue.Values.ModbusValue.ToString()
            //        + " , " + aValue.Values.Value.ToString()
            //        + " , " + aValue.Values.OPCValue.ToString()
            //        + " , " + aModbusItem.Status.ToString());
            //}

            //写圈或写寄存器模式
            CoilOrRegister iCoilOrRegiterMode = CoilOrRegister.Register;

            //写长度
            UInt16 uint16WriteLenth = 0;

            //写缓存
            byte[] bWriteBuffer = new byte[0];

            //写数值
            ItemValue ivItemValue = new ItemValue();

            //判断数据类型
            switch (aModbusItem.ItemType)
            {
                //WORD类型打包
                case "WORD":
                    ivItemValue.Word = Convert.ToInt16(aValue.Values.Value.ToString());
                    bWriteBuffer = new byte[2];
                    bWriteBuffer[0] = ivItemValue.B1;
                    bWriteBuffer[1] = ivItemValue.B0;
                    uint16WriteLenth = 1;
                    break;

                //DWORD类型打包
                case "DWORD":
                    ivItemValue.DWord = Convert.ToInt32(aValue.Values.Value.ToString());
                    bWriteBuffer = new byte[4];
                    bWriteBuffer[0] = ivItemValue.B1;
                    bWriteBuffer[1] = ivItemValue.B0;
                    bWriteBuffer[2] = ivItemValue.B3;
                    bWriteBuffer[3] = ivItemValue.B2;
                    uint16WriteLenth = 2;
                    break;

                //FLOAT类型打包
                case "FLOAT":
                    ivItemValue.Float = (float)Convert.ToDouble(aValue.Values.Value.ToString());
                    bWriteBuffer = new byte[4];
                    bWriteBuffer[0] = ivItemValue.B1;
                    bWriteBuffer[1] = ivItemValue.B0;
                    bWriteBuffer[2] = ivItemValue.B3;
                    bWriteBuffer[3] = ivItemValue.B2;
                    uint16WriteLenth = 2;
                    break;

                //STRING类型打包
                case "STRING":
                    //数值转换为字符串
                    string strValue = Convert.ToString(aValue.Values.Value.ToString());

                    //缓存
                    bWriteBuffer = new byte[10];
                    //char[] cBuffer = new char[10];

                    //数据打包
                    for (int i = 0; i < bWriteBuffer.Length && i < strValue.Length; i++) bWriteBuffer[i] = (byte)strValue[i];

                    //Array.Copy((byte[])cBuffer, 0, bWriteBuffer, 0, 10);
                    uint16WriteLenth = 5;
                    break;
                case "BOOLEAN":
                    iCoilOrRegiterMode = CoilOrRegister.Coil;
                    bWriteBuffer = new byte[1];
                    bWriteBuffer[0] = Convert.ToByte(aValue.Values.Value);
                    uint16WriteLenth = 1;
                    break;
                default:
                    uint16WriteLenth = 0;
                    break;
            }

            //写
            if (uint16WriteLenth > 0)
            {
                switch (iCoilOrRegiterMode)
                {
                    case CoilOrRegister.Coil:
                        //写线圈
                        if (WriteSingleCoil(aModbusItem.SlaveID, aModbusItem.ItemAddress, Convert.ToUInt16(bWriteBuffer[0])) == uint16WriteLenth)
                        {
                            //更新值
                            aModbusItem.Value = aValue.Values.Value;
                            aModbusItem.UpdateTime = DateTime.Now;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //break;
                    case CoilOrRegister.Register:
                        //写寄存器
                        if (WriteMultipleRegisters(aModbusItem.SlaveID, aModbusItem.ItemAddress, uint16WriteLenth, bWriteBuffer) == uint16WriteLenth * 2)
                        {
                            //更新值
                            aModbusItem.Value = aValue.Values.Value;
                            aModbusItem.UpdateTime = DateTime.Now;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //break;
                    default:
                        return false;
                        //break;
                }
               
            }
            else
            {
                return false;
            }

            //return true;
        }

    }
}
