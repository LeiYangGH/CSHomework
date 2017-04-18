using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWarehouse
{
    public class Result
    {
        [DisplayName("操作类型")]
        public string Type { get; set; }
        [DisplayName("配件名称")]
        public string Name { get; set; }
        [DisplayName("价格")]
        public Nullable<decimal> Price { get; set; }
        [DisplayName("数量")]
        public int Quantity { get; set; }
        [DisplayName("时间")]
        public Nullable<System.DateTime> Date { get; set; }
    }
}
