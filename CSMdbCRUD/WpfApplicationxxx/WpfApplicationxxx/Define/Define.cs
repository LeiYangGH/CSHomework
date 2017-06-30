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
 * 功能描述：数据类型定义
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataExchang.Define
{
    /// <summary>
    /// modbus读写模式
    /// </summary>
    public enum CoilOrRegister
    { 
        /// <summary>
        /// 线圈
        /// </summary>
        Coil,

        /// <summary>
        /// 寄存器
        /// </summary>
        Register
    }

    /// <summary>
    /// HMI按钮状态状态
    /// </summary>
    public enum HMIEventState
    { 
        /// <summary>
        /// 开
        /// </summary>
        ON,

        /// <summary>
        /// 关
        /// </summary>
        OFF,

        /// <summary>
        /// 暂停
        /// </summary>
        Pause,

        /// <summary>
        /// 计数
        /// </summary>
        Counting,

        /// <summary>
        /// 清空箱开机报废数
        /// </summary>
        ClearBinStartMachineScrap,

        /// <summary>
        /// 清空批开机报废数
        /// </summary>
        ClearBatchStartMachineScrap,

        /// <summary>
        /// 其他
        /// </summary>
        Else
    }

    /// <summary>
    /// 读取模式
    /// </summary>
    public enum RwDirection
    {
        /// <summary>
        /// 读
        /// </summary>
        Read,

        /// <summary>
        ///写 
        /// </summary>
        Write,

        /// <summary>
        /// 读写
        /// </summary>
        ReadWrite
    };

    /// <summary>
    /// 变量数值类型解析结构
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ItemValue
    {
        [FieldOffset(0)]
        public byte B0;

        [FieldOffset(1)]
        public byte B1;

        [FieldOffset(2)]
        public byte B2;

        [FieldOffset(3)]
        public byte B3;

        [FieldOffset(0)]
        public byte B;

        [FieldOffset(0)]
        public Int16 Word;

        [FieldOffset(0)]
        public Int32 DWord;

        [FieldOffset(0)]
        public float Float;

        [FieldOffset(0)]
        public float FloatInverse;
    };

    /// <summary>
    /// modbus变量属性类
    /// </summary>
    public class ModbusItem
    {
        /// <summary>
        /// 排列号
        /// </summary>
        public int ListNumber;

        /// <summary>
        /// code
        /// </summary>
        public string ItemCode = "";

        /// <summary>
        /// 变量名
        /// </summary>
        public string ItemName = "";

        /// <summary>
        /// 工作ID
        /// </summary>
        public byte SlaveID = 0;

        /// <summary>
        /// 变量地址
        /// </summary>
        public UInt16 ItemAddress = 0;

        /// <summary>
        /// 变量类型
        /// </summary>
        public string ItemType = "";

        /// <summary>
        /// 读写方向
        /// </summary>
        public RwDirection Direction = RwDirection.Read;

        /// <summary>
        /// 更新时间戳
        /// </summary>
        public DateTime UpdateTime = DateTime.Now;

        /// <summary>
        /// 状态
        /// </summary>
        public ValueState Status = ValueState.STATUS_BAD;

        /// <summary>
        /// 值
        /// </summary>
        public object Value = 0;
    }

    /// <summary>
    /// OPC变量属性类
    /// </summary>
    public class OPCItemClass
    {
        /// <summary>
        /// 排列号
        /// </summary>
        public int ListNumber;

        /// <summary>
        /// 变量名
        /// </summary>
        public string ItemName = "";

        /// <summary>
        /// 变量地址
        /// </summary>
        public string ItemAddress = "";

        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName = "";

        /// <summary>
        /// 变量类型
        /// </summary>
        public string ItemType = "";

        /// <summary>
        /// 读写方向
        /// </summary>
        public RwDirection Direction = RwDirection.Read;

        /// <summary>
        /// 更新时间戳
        /// </summary>
        public DateTime UpdateTime = DateTime.Now;

        /// <summary>
        /// 状态
        /// </summary>
        public ValueState Status = ValueState.STATUS_BAD;

        /// <summary>
        /// 值
        /// </summary>
        public object Value = 0;
    }

    /// <summary>
    /// 变量值类
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// 值
        /// </summary>
        public object Value = 0;

        /// <summary>
        /// OPC值
        /// </summary>
        public object OPCValue = 0;

        /// <summary>
        /// Modbus值
        /// </summary>
        public object ModbusValue = 0;

        /// <summary>
        /// modbus状态
        /// </summary>
        public ValueState ModbusStatus = ValueState.STATUS_GOOG;

        /// <summary>
        /// OPC状态
        /// </summary>
        public ValueState OPCStatus = ValueState.STATUS_GOOG;

        /// <summary>
        /// 更新时间戳
        /// </summary>
        public DateTime UpdateTime = DateTime.Now;

        /// <summary>
        /// 变量类型
        /// </summary>
        public string ItemType = "";

        /// <summary>
        /// 事件信号
        /// </summary>
        public bool EventFlag = false;
    }

    /// <summary>
    /// 数据库IOLIST类
    /// </summary>
    public class Iolist
    {
        /// <summary>
        /// 排列号
        /// </summary>
        public int ListNumber = 0;

        /// <summary>
        /// 变量code
        /// </summary>
        public string TagCode = "";

        /// <summary>
        /// 变量名
        /// </summary>
        public string TagName = "";

        /// <summary>
        /// 中文说明
        /// </summary>
        public string TagNameZhDifine = "";

        /// <summary>
        /// 英文说明
        /// </summary>
        public string TagNameEnDifine = "";

        /// <summary>
        /// 变量类型
        /// </summary>
        public string VarType = "";

        /// <summary>
        /// opc ip地址
        /// </summary>
        public string OpcHost = "";

        /// <summary>
        /// opc 名称
        /// </summary>
        public string OpcName = "";

        /// <summary>
        /// opc变量地址
        /// </summary>
        public string OpcPath = "";

        /// <summary>
        /// PLC地址
        /// </summary>
        public string PlcAddress = "";

        /// <summary>
        /// modbus地址
        /// </summary>
        public string ModbusAddress = "";

        /// <summary>
        /// 读取来源
        /// </summary>
        public string Source = "";

        /// <summary>
        /// modbusTCP ip地址
        /// </summary>
        public string ModbusIP = "";

        /// <summary>
        /// modbusTCP 端口
        /// </summary>
        public string ModbusPort = "";

        /// <summary>
        /// Slave address
        /// </summary>
        public int ModbusSlaveID = 0;

        ///// <summary>
        ///// modbus值
        ///// </summary>
        //public Variable ModbusVariable = new Variable();

        ///// <summary>
        ///// PLC值
        ///// </summary>
        //public Variable PLCVariable = new Variable();

        /// <summary>
        /// 值
        /// </summary>
        public Variable Values = new Variable();

        /// <summary>
        /// HMI读写方式
        /// </summary>
        public string HMIMode = "";

        /// <summary>
        /// PLC读写方式
        /// </summary>
        public string PLCMode = "";

        /// <summary>
        /// 互斥锁
        /// </summary>
        public int Locked = 0;

        /// <summary>
        /// 浸渍线
        /// </summary>
        public string DippingLineID = "";

        /// <summary>
        /// 是否是半条线
        /// </summary>
        public string IsHalf = "0";
    }

    /// <summary>
    /// OPC变量组
    /// </summary>
    class GroupItem
    {
        /// <summary>
        /// 组
        /// </summary>
        public string GroupName;

        /// <summary>
        /// 变量名表
        /// </summary>
        public string[] StrItem;

        /// <summary>
        /// 变量list
        /// </summary>
        public OPCItemClass[] Item;
    }

    public enum ValueState
    {
        /// <summary>
        /// 状态良好
        /// </summary>
        STATUS_GOOG = 0,

        /// <summary>
        /// 状态坏
        /// </summary>
        STATUS_BAD
    }
}
