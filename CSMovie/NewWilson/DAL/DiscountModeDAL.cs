using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiscountModeDAL
    {
        public DiscountMode FromSqlDataReader(SqlDataReader reader)
        {
            DiscountMode obj = new DiscountMode();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToByte(reader["id"]);
            }
            if (reader["name"] is DBNull == false)
            {
                obj.Name = Convert.ToString(reader["name"]);
            }
            return obj;
        }

        public List<DiscountMode> GetAllDiscount()
        {
            throw new NotImplementedException();
        }
        public byte Insert(DiscountMode discountMode)
        {
            throw new NotImplementedException();
        }
        public void Delete(byte discountModeId)
        {
            throw new NotImplementedException();
        }
        public void Update(DiscountMode discountMode)
        {
            throw new NotImplementedException();
        }
        public DiscountMode Search(byte discountId)
        {
            throw new NotImplementedException();
        }
        public List<DiscountMode> Search(string unclearName)
        {
            throw new NotImplementedException();
        }
    }
}
