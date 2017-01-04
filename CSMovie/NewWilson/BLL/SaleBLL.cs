using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class SaleBLL
    {
        private SaleDAL dal = new SaleDAL();
        public List<Position> GetSoldPositionsByMovieName(string movieName)
        {
            return dal.GetSoldPositionsByMovieName(movieName);
        }
        public bool InsertSale(Sale sale)
        {
            return dal.InsertSale(sale);
        }
    }
}

