using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiscountDAL
    {
        public Discount FromSqlDataReader(SqlDataReader reader)
        {
            Discount obj = new Discount();
            if (reader["customerTypeId"] is DBNull == false)
            {
                obj.CustomerTypeId = Convert.ToByte(reader["customerTypeId"]);
            }
            if (reader["discountModeId"] is DBNull == false)
            {
                obj.DiscountModeId = Convert.ToByte(reader["discountModeId"]);
            }
            if (reader["number"] is DBNull == false)
            {
                obj.Number = Convert.ToDecimal(reader["number"]);
            }
            if (reader["startDateTime"] is DBNull == false)
            {
                obj.StartDateTime = Convert.ToDateTime(reader["startDateTime"]);
            }
            if (reader["duration"] is DBNull == false)
            {
                obj.Duration = Convert.ToInt32(reader["duration"]);
            }
            if (reader["coustomerTypeName"] is DBNull == false)
            {
                obj.CoustomerTypeName = Convert.ToString(reader["coustomerTypeName"]);
            }
            if (reader["discountModeName"] is DBNull == false)
            {
                obj.DiscountModeName = Convert.ToString(reader["discountModeName"]);
            }
            return obj;
        }

        public List<Discount> GetAllDiscount()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 按顾客类型获取所有可能的折扣方案
        /// </summary>
        /// <param name="customerTypeId"></param>
        /// <returns></returns>
        public List<Discount> Search(byte customerTypeId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取从某一天开始, 某一种顾客类型能获取的折扣列表
        /// </summary>
        /// <param name="from"></param>
        /// <param name="customerTypeId"></param>
        /// <returns></returns>
        public List<Discount> Search(DateTime from, byte customerTypeId)
        {
            throw new NotImplementedException();
        }
        public void Insert(Discount discount)
        {
            throw new NotImplementedException();
        }
        public void Update(Discount discount)
        {
            throw new NotImplementedException();
        }
        public void Delete(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}
