using Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DiscountBLL
    {
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
