using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTreeGrid.DAL
{
    /// <summary>
    /// 主界面表格绑定的类型，各个字段名称可以任意重命名（比如中文）
    /// </summary>
    public class Goods
    {
        public int Id { get; set; }//自增id
        public string Category { get; set; }//类别
        public string Name { get; set; }//名称
        public double PrePrice { get; set; }//原价
        public bool isSpecial { get; set; }//特价与否
        public double Price { get; set; }//新价

    }
}
