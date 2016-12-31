using Model;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
