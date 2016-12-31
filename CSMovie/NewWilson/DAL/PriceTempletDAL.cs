using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class PriceTempletDAL
    {
        public PriceTemplet FromSqlDataReader(SqlDataReader reader)
        {
            PriceTemplet obj = new PriceTemplet();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToInt32(reader["id"]);
            }
            if (reader["price"] is DBNull == false)
            {
                obj.Price = Convert.ToDecimal(reader["price"]);
            }
            if (reader["name"] is DBNull == false)
            {
                obj.Name = Convert.ToString(reader["name"]);
            }
            return obj;
        }
        public List<PriceTemplet> GetAllPriceTemplet()
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 按照价格模板名的模糊匹配
        /// </summary>
        /// <param name="unclearName"></param>
        /// <returns></returns>
        public List<PriceTemplet> Search(string unclearName)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 按照一个价格区间匹配符合的价格模板
        /// </summary>
        /// <param name="leftBound"></param>
        /// <param name="rightBound"></param>
        /// <returns></returns>
        public List<PriceTemplet> Search(decimal leftBound, decimal rightBound)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 匹配 某个值 一定范围的价格模板
        /// </summary>
        /// <param name="basePrice">基础价格</param>
        /// <param name="radias">价格浮动大小</param>
        /// <returns></returns>
        public List<PriceTemplet> Search(decimal basePrice, int radias)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 精确查找一个id的价格模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PriceTemplet Search(int id)
        {
            throw new NotFiniteNumberException();
        }
        public int InsertPriceTemplet(PriceTemplet priceTemplet)
        {
            throw new NotFiniteNumberException();
        }
        public void DeletePriceTemplet(int id)
        {
            throw new NotFiniteNumberException();
        }
        public void UpdatepriceTemplet(PriceTemplet priceTemplet)
        {
            throw new NotFiniteNumberException();
        }
    }
}
