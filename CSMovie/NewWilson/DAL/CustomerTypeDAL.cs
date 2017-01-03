using Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CustomerTypeDAL
    {
        public CustomerType FromSqlDataReader(SqlDataReader reader)
        {
            CustomerType obj = new CustomerType();
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

        public List<CustomerType> GetAllCustomerType()
        {
            List<CustomerType> mes = new List<CustomerType>();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from [customerType]", conn);
                da.Fill(dt);
            }
            return dt.Rows.OfType<DataRow>().Select(x =>
            new CustomerType()
            {
                Id = (byte)(x[0]),
                Name = x[1].ToString()
            }
            ).ToList();
        }
        public int Insert(CustomerType customerType)
        {
            throw new NotImplementedException();
        }
        public void Delete(int coustomerTypeId)
        {
            throw new NotImplementedException();
        }
        public void Update(CustomerType customerType)
        {
            throw new NotImplementedException();
        }
        public List<CustomerType> Search(string unclearName)
        {
            throw new NotImplementedException();
        }
        public CustomerType Search(byte id)
        {
            throw new NotImplementedException();
        }
    }
}
