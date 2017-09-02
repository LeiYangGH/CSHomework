using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckNumException
{
    public class CalcTotal
    {
        public double GetTotal(string strPrice, string strQuantity)
        {
            double price;
            double quatity;
            if (double.TryParse(strPrice, out price)
                && double.TryParse(strQuantity, out quatity))
            {
                if (price > 0 && quatity > 0)
                    return price * quatity;
                else
                    throw new CalcTotalException("单价或数量不能为负数！");
            }
            else
            {
                throw new CalcTotalException("单价或数量必须为数字！");
            }

        }


    }
}
