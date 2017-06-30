using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExchang.Class
{
    abstract class ModbusClass
    {
        /// <summary>
        /// 连接接口
        /// </summary>
        abstract public bool Connect();

        /// <summary>
        /// 断开连接接口
        /// </summary>
        abstract public void DisConnect();
    }
}
