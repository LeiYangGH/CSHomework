using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankHomework
{
    public class Exchange
    {
        private const string dateFormatString = @"yyyy-MM-dd HH:mm:ss";

        public Exchange(string name, double rmb, DateTime time)
        {
            this.Name = name;
            this.RMB = rmb;
            this.Time = time;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        public double RMB
        {
            get;
            set;
        }

        /// <summary>
        /// 日期时间
        /// </summary>
        public DateTime Time
        {
            get;
            set;
        }

        /// <summary>
        /// 从txt的一行解析出各个字段
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Exchange CreateExchangeFromLine(string line)
        {
            string[] ss = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return new Exchange(
                ss[0].Trim(),
                Convert.ToDouble(ss[1].Trim()),
                Convert.ToDateTime(ss[2].Trim()));
        }

        /// <summary>
        /// 从各个字段组合成一行
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2}",
                this.Name, this.RMB, this.Time.ToString(dateFormatString));
        }
    }
}
