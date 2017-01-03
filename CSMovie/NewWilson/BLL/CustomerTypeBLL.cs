using Model;
using System;
using System.Collections.Generic;
using DAL;
namespace BLL
{
    public class CustomerTypeBLL
    {
        private CustomerTypeDAL dal = new CustomerTypeDAL();

        public List<CustomerType> GetAllCustomerType()
        {
            return dal.GetAllCustomerType();
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
